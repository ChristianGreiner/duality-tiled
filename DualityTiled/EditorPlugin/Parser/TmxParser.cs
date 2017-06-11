using System.Collections.Generic;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;
using System;
using System.IO;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Parser.Xml;
using ChristianGreiner.Duality.Plugins.DualityTiled.Misc;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public class TmxParser : ITiledParser<IElement>
    {
        public ContentRef<TiledMap> Tilemap { get; }

        public string RawData { get; }

        public TmxParser(ref ContentRef<TiledMap> contentRef, string rawData)
        {
            Tilemap = contentRef;
            RawData = rawData;
        }

        public void Parse()
        {
            if (!Tilemap.IsAvailable) return;

            var xmlParser = new XmlParser();
            var xmlDocument = xmlParser.Parse(RawData);
            var mapElement = xmlDocument.FirstElementChild;

            Tilemap.Res.Version = GetValueFromAttribute<string>(mapElement, "version");
            Tilemap.Res.Size = GetVec2FromAttributes(mapElement, "width", "height").ToPoint2();
            Tilemap.Res.TileSize = GetVec2FromAttributes(mapElement, "tilewidth", "tileheight").ToPoint2();

            var renderorder = GetValueFromAttribute<string>(mapElement, "renderorder");
            switch (renderorder)
            {
                case "right-down":
                    Tilemap.Res.Renderorder = TiledRenderorder.RightDown;
                    break;

                case "right-up":
                    Tilemap.Res.Renderorder = TiledRenderorder.RightUp;
                    break;

                case "left-down":
                    Tilemap.Res.Renderorder = TiledRenderorder.LeftDown;
                    break;

                case "left-up":
                    Tilemap.Res.Renderorder = TiledRenderorder.LeftUp;
                    break;
            }

            // TODO: StaggerAxis, StaggerIndex

            Tilemap.Res.NextObjectId = GetValueFromAttribute<int>(mapElement, "nextobjectid");

            // (optional) map properties
            var properties = mapElement.GetElementsByTagName("properties").FirstOrDefault();
            Tilemap.Res.Properties = ParseProperties(properties);

            // check if map uses an external tileset file

            Tilemap.Res.Layer = ParseTiledLayers(mapElement);
        }

        public List<TiledTileset> ParseTilesets(IElement data)
        {
            var tilesetElements = data?.GetElementsByTagName("tileset");

            List<TiledTileset> tilesets = new List<TiledTileset>();

            if (tilesetElements?.Length > 0)
            {
                foreach (var element in tilesetElements)
                {
                    var tileset = new TiledTileset();
                    // parse attributes
                    tileset.FirstGid = GetValueFromAttribute<int>(element, "firstgid");

                    // external tileset?
                    var source = GetValueFromAttribute<string>(element, "source");
                    if (!string.IsNullOrEmpty(source))
                    {
                        // open external tileset
                    }

                    // TODO: image element, parse custom tile properties

                    tilesets.Add(tileset);
                }
            }

            // apply tilset to content ref
            if (Tilemap.IsAvailable)
                Tilemap.Res.Tilesets = tilesets;

            return tilesets;
        }

        private void ParseTilesetAttributes(TiledTileset tileset, IElement xmlTileset)
        {
            tileset.Name = GetValueFromAttribute<string>(xmlTileset, "name");
            tileset.TileSize = GetVec2FromAttributes(xmlTileset, "tilewidth", "tileheight").ToPoint2();

            tileset.TileCount = GetValueFromAttribute<int>(xmlTileset, "tilecount");
            tileset.Columns = GetValueFromAttribute<int>(xmlTileset, "columns");

            var imageElement = xmlTileset.GetElementsByTagName("image").FirstOrDefault();
            tileset.Source = GetValueFromAttribute<string>(imageElement, "source");

            // parse optional attributes
            tileset.Spacing = GetValueFromAttribute<int>(xmlTileset, "spacing");
            tileset.Margin = GetValueFromAttribute<int>(xmlTileset, "margin");
        }

        public List<ITiledLayer> ParseTiledLayers(IElement data)
        {
            var layerList = new List<ITiledLayer>();

            foreach (var child in data.Children)
            {
                // check if layer are stored in a group
                if (child.TagName.Equals("group"))
                {
                    foreach (var groupElement in child.Children)
                    {
                        var groupLayer = ParseLayer(groupElement);
                        if (groupLayer != null)
                            layerList.Add(groupLayer);
                    }
                }

                var layer = ParseLayer(child);
                if (layer != null)
                    layerList.Add(layer);
            }

            return layerList;
        }

        private ITiledLayer ParseLayer(IElement data)
        {
            if (data.TagName.Equals("layer"))
                return ParseTiledLayer(data);

            if (data.TagName.Equals("objectgroup"))
            {
                return ParseObjectgroup(data);
            }

            if (data.TagName.Equals("imagelayer"))
            {
                throw new NotImplementedException("Imageslayer are not supported yet.");
            }

            return null;
        }

        /// <summary>
        /// Parse a single layer with tile data.
        /// </summary>
        /// <param name="data">The xml element.</param>
        /// <returns>The layer.</returns>
        public TiledLayer ParseTiledLayer(IElement data)
        {
            var layer = new TiledLayer();

            ParseDefaultLayerAttributes(data, layer);

            // layer data
            var dataElement = data.GetElementsByTagName("data").FirstOrDefault();
            if (dataElement != null)
                layer.Data = EncodeData(dataElement, layer.Size);

            return layer;
        }

        public TiledObjectgroup ParseObjectgroup(IElement data)
        {
            var group = new TiledObjectgroup();

            ParseDefaultLayerAttributes(data, group);

            // parse objects
            var objectElements = data.GetElementsByTagName("object");
            if (objectElements != null)
            {
                foreach (var objectElement in objectElements)
                {
                    var obj = ParseTiledObject(objectElement);
                    if (obj != null)
                        group.Objects.Add(obj);
                }
            }

            return group;
        }

        private void ParseDefaultLayerAttributes(IElement xmlElement, ITiledLayer layer)
        {
            // name
            layer.Name = GetValueFromAttribute<string>(xmlElement, "name");

            // size
            layer.Size = GetVec2FromAttributes(xmlElement, "width", "height").ToPoint2();

            // opacity
            var opacityValue = xmlElement?.Attributes.FirstOrDefault(a => a.Name.Equals("opacity"))?.Value;
            if (opacityValue != null)
                layer.Opacity = float.Parse(opacityValue);

            // offset
            layer.Offset = GetVec2FromAttributes(xmlElement, "offsetx", "offsety").ToPoint2();

            // properties
            var propertiesElement = xmlElement?.GetElementsByTagName("properties").FirstOrDefault();
            if (propertiesElement != null)
                layer.Properties = ParseProperties(propertiesElement);
        }

        public TiledObject ParseTiledObject(IElement data)
        {
            TiledObject tiledObj = null;

            // check if object is a polygon
            var polygonElement = data.GetElementsByTagName("polygon").FirstOrDefault();
            if (polygonElement != null)
            {
                tiledObj = new TiledPolygon();
                var polygonObject = (TiledPolygon)tiledObj;
                polygonObject.Points = GetPolyPoints(polygonElement);
            }

            var ellipseElement = data.GetElementsByTagName("ellipse").FirstOrDefault();
            if (ellipseElement != null)
            {
                tiledObj = new TiledEllipse();
            }

            var polylineElement = data.GetElementsByTagName("polyline").FirstOrDefault();
            if (polylineElement != null)
            {
                tiledObj = new TiledPolyline();
                var polylineObject = (TiledPolyline)tiledObj;
                polylineObject.Points = GetPolyPoints(polygonElement);
            }

            if (tiledObj != null)
            {
                tiledObj.Id = GetValueFromAttribute<uint>(data, "id");
                tiledObj.Name = GetValueFromAttribute<string>(data, "name");
                tiledObj.Type = GetValueFromAttribute<string>(data, "type");
                tiledObj.Size = GetVec2FromAttributes(data, "width", "height");
                tiledObj.Position = GetVec2FromAttributes(data, "x", "y");
            }

            return tiledObj;
        }

        private List<Vector2> GetPolyPoints(IElement polygonElement)
        {
            if (polygonElement == null) return new List<Vector2>();
            var points = new List<Vector2>();
            var pointsString = GetValueFromAttribute<string>(polygonElement, "points").Split(' ');

            foreach (var point in pointsString)
            {
                var pointX = float.Parse(point.Split(',')[0]);
                var pointY = float.Parse(point.Split(',')[1]);
                points.Add(new Vector2(pointX, pointY));
            }

            return points;
        }

        public TiledData EncodeData(IElement data, Point2 gridSize)
        {
            var rawData = data.InnerHtml;

            // get encoding
            var encoding = GetValueFromAttribute<string>(data, "encoding");
            var compression = GetValueFromAttribute<string>(data, "compression");

            var tiledEncoding = TiledEncoding.Base64;
            var tiledCompression = TiledCompression.None;
            var tileGrid = new Grid<uint>(gridSize.X, gridSize.Y);
            var idList = new List<uint>();

            switch (encoding)
            {
                // xml encoding
                case null:
                    tiledEncoding = TiledEncoding.Xml;

                    foreach (var child in data.Children)
                    {
                        if (child.TagName.Equals("tile"))
                            idList.Add(GetValueFromAttribute<uint>(child, "gid"));
                    }
                    break;

                case "csv":
                    tiledEncoding = TiledEncoding.Csv;
                    idList.AddRange(rawData.Split(',').Select(uint.Parse));
                    break;

                case "base64":
                    tiledEncoding = TiledEncoding.Base64;
                    BinaryReader bnReader = null;

                    // check the compression
                    switch (compression)
                    {
                        // no compression used
                        case null:
                            tiledCompression = TiledCompression.None;
                            bnReader = new BinaryReader(TiledDecoder.Decode(rawData));
                            break;

                        case "zlib":
                            tiledCompression = TiledCompression.Zlib;
                            bnReader = new BinaryReader(TiledDecoder.DecodeZlib(rawData));
                            break;

                        case "gzip":
                            tiledCompression = TiledCompression.Gzip;
                            bnReader = new BinaryReader(TiledDecoder.DecodeGzip(rawData));
                            break;
                    }

                    if (bnReader != null)
                    {
                        using (bnReader)
                        {
                            for (int y = 0; y < tileGrid.Height; y++)
                                for (int x = 0; x < tileGrid.Width; x++)
                                    idList.Add(bnReader.ReadUInt32());
                        }
                    }
                    break;
            }

            tileGrid = new Grid<uint>((int)gridSize.X, (int)gridSize.Y, idList.ToArray());

            return new TiledData()
            {
                Compression = tiledCompression,
                Encoding = tiledEncoding,
                Tiles = tileGrid
            };
        }

        public List<TiledProperty> ParseProperties(IElement data)
        {
            if (data != null)
            {
                var properties = new List<TiledProperty>();
                foreach (var property in data.Children)
                {
                    var xmlName = GetValueFromAttribute<string>(property, "name");
                    var xmlTypeName = GetValueFromAttribute<string>(property, "type");
                    var xmlValue = GetValueFromAttribute<string>(property, "value");

                    Type propertyType = null;

                    switch (xmlTypeName)
                    {
                        case "string":
                            propertyType = typeof(string);
                            break;

                        case "":
                            propertyType = typeof(string);
                            break;

                        case "int":
                            propertyType = typeof(int);
                            break;

                        case "float":
                            propertyType = typeof(float);
                            break;

                        case "bool":
                            propertyType = typeof(bool);
                            break;

                        case "color":
                            throw new NotImplementedException("Colors not implmented yet.");
                            break;

                        case "file":
                            propertyType = typeof(string);
                            break;

                        default:
                            propertyType = typeof(string);
                            break;
                    }

                    var propertyValue = Convert.ChangeType(xmlValue, propertyType);
                    properties.Add(new TiledProperty(xmlName, propertyType, propertyValue));
                }

                return properties;
            }

            return null;
        }

        private Vector2 GetVec2FromAttributes(IElement element, params string[] attributes)
        {
            if (element == null)
                return Vector2.Zero;

            if (attributes.Length > 2)
                throw new ArgumentException("There should be only two attributes.");

            var valueA = GetValueFromAttribute<float>(element, attributes[0]);
            var valueB = GetValueFromAttribute<float>(element, attributes[1]);
            return new Vector2(valueA, valueB);
        }

        private T GetValueFromAttribute<T>(IElement element, string attribute)
        {
            var result = element?.Attributes.FirstOrDefault(a => a.Name.Equals(attribute));
            if (result != null)
                return (T)Convert.ChangeType(result.Value, typeof(T));
            return default(T);
        }
    }
}