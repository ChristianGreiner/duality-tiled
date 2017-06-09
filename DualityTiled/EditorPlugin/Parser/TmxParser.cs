using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Parser.Xml;
using ChristianGreiner.Duality.Plugins.DualityTiled.Misc;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;
using Duality.Drawing;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public class TmxParser : ITiledParser
    {
        public TiledMap ParseMap(ref ContentRef<TiledMap> contentRef, object data)
        {
            if (data == null)
                throw new NullReferenceException("Data is null!");

            var xmlParser = new XmlParser();
            var xmlDocument = xmlParser.Parse((string)data);
            var map = contentRef.Res;

            var mapElement = xmlDocument.GetElementsByTagName("map").FirstOrDefault();

            if (mapElement == null)
                throw new NullReferenceException("Map format is invalid.");

            map.Version = GetValueFromAttribute<string>(mapElement, "version");
            map.Size = GetVec2FromAttributes(mapElement, "width", "height").ToPoint2();
            map.TileSize = GetVec2FromAttributes(mapElement, "tilewidth", "tileheight").ToPoint2();

            var renderorder = GetValueFromAttribute<string>(mapElement, "renderorder");
            switch (renderorder)
            {
                case "right-down":
                    map.Renderorder = TiledRenderorder.RightDown;
                    break;

                case "right-up":
                    map.Renderorder = TiledRenderorder.RightUp;
                    break;

                case "left-down":
                    map.Renderorder = TiledRenderorder.LeftDown;
                    break;

                case "left-up":
                    map.Renderorder = TiledRenderorder.LeftUp;
                    break;
            }

            // TODO: StaggerAxis, StaggerIndex

            map.NextObjectId = GetValueFromAttribute<int>(mapElement, "nextobjectid");

            // (optional) map properties
            var properties = mapElement.GetElementsByTagName("properties").FirstOrDefault();
            map.Properties = ParseProperties(properties);

            ParseTileset(ref contentRef, mapElement);
            ParseLayer(ref contentRef, mapElement);

            return map;
        }

        public List<TiledTileset> ParseTileset(ref ContentRef<TiledMap> contentRef, object data)
        {
            var mapElement = (IElement)data;
            var tilesetElements = mapElement?.GetElementsByTagName("tileset");

            if (tilesetElements?.Length > 0)
            {
                contentRef.Res.Tilesets = new List<TiledTileset>();

                foreach (var tilesetElement in tilesetElements)
                {
                    var tiledTileset = new TiledTileset();

                    // parse attributes
                    tiledTileset.FirstGid = GetValueFromAttribute<int>(tilesetElement, "firstgid");
                    tiledTileset.Name = GetValueFromAttribute<string>(tilesetElement, "name");
                    tiledTileset.TileSize = GetVec2FromAttributes(tilesetElement, "tilewidth", "tileheight").ToPoint2();

                    tiledTileset.TileCount = GetValueFromAttribute<int>(tilesetElement, "tilecount");
                    tiledTileset.Columns = GetValueFromAttribute<int>(tilesetElement, "columns");

                    // parse optional attributes
                    tiledTileset.Spacing = GetValueFromAttribute<int>(tilesetElement, "spacing");
                    tiledTileset.Margin = GetValueFromAttribute<int>(tilesetElement, "margin");

                    // TODO: image element

                    // TODO: parse custom tile properties

                    contentRef.Res.Tilesets.Add(tiledTileset);
                }
            }

            return contentRef.Res.Tilesets;
        }

        public List<ITiledLayer> ParseLayer(ref ContentRef<TiledMap> contentRef, object data)
        {
            var mapElement = (IElement)data;

            contentRef.Res.Layer = new List<ITiledLayer>();

            foreach (var childElement in mapElement.Children)
            {
                if (childElement.TagName.Equals("group"))
                {
                    foreach (var groupElement in childElement.Children)
                        ParseLayerTypes(ref contentRef, groupElement);
                }
                else
                    ParseLayerTypes(ref contentRef, childElement);
            }

            return contentRef.Res.Layer;
        }

        private void ParseLayerTypes(ref ContentRef<TiledMap> contentRef, IElement xmlElement)
        {
            if (xmlElement.TagName.Equals("layer"))
                contentRef.Res.Layer.Add(ParseTiledLayer(xmlElement));

            if (xmlElement.TagName.Equals("objectgroup"))
            {
                contentRef.Res.Layer.Add(ParseObjectgroup(xmlElement));
            }

            if (xmlElement.TagName.Equals("imagelayer"))
            {
                throw new NotImplementedException("Imageslayer are not supported yet.");
            }
        }

        private ITiledLayer ParseTiledLayer(IElement xmlElement)
        {
            var layer = new TiledLayer();

            ParseDefaultLayerAttributes(xmlElement, layer);
            layer.Properties = ParseProperties(xmlElement);

            // layer data
            var dataElement = xmlElement.GetElementsByTagName("data").FirstOrDefault();
            if (dataElement != null)
            {
                layer.Data = EncodeData(dataElement, layer.Size);
            }

            return layer;
        }

        private ITiledLayer ParseObjectgroup(IElement xmlElement)
        {
            var group = new TiledObjectgroup();

            ParseDefaultLayerAttributes(xmlElement, group);
            group.Properties = ParseProperties(xmlElement);

            // parse objects
            var objectElements = xmlElement.GetElementsByTagName("object");
            if (objectElements != null)
            {
                group.Objects = new List<TiledObject>();

                foreach (var objectElement in objectElements)
                {
                    TiledObject tiledObj = null;

                    // check if object is a polygon
                    var polygonElement = objectElement.GetElementsByTagName("polygon").FirstOrDefault();
                    if (polygonElement != null)
                    {
                        tiledObj = new TiledPolygon();
                        var polygonObject = (TiledPolygon)tiledObj;
                        polygonObject.Points = GetPolyPoints(polygonElement);
                    }

                    var ellipseElement = objectElement.GetElementsByTagName("ellipse").FirstOrDefault();
                    if (ellipseElement != null)
                    {
                        tiledObj = new TiledEllipse();
                    }

                    var polylineElement = objectElement.GetElementsByTagName("polyline").FirstOrDefault();
                    if (polylineElement != null)
                    {
                        tiledObj = new TiledPolyline();
                        var polylineObject = (TiledPolyline)tiledObj;
                        polylineObject.Points = GetPolyPoints(polygonElement);
                    }

                    if (tiledObj != null)
                    {
                        tiledObj.Id = GetValueFromAttribute<uint>(objectElement, "id");
                        tiledObj.Name = GetValueFromAttribute<string>(objectElement, "name");
                        tiledObj.Type = GetValueFromAttribute<string>(objectElement, "type");
                        tiledObj.Size = GetVec2FromAttributes(objectElement, "width", "height");
                        tiledObj.Position = GetVec2FromAttributes(objectElement, "x", "y");

                        group.Objects.Add(tiledObj);
                    }
                }
            }

            return group;
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

        public TiledData EncodeData(object data, Point2 gridSize)
        {
            var dataElement = (IElement)data;
            var rawData = dataElement.InnerHtml;

            // get encoding
            var encoding = GetValueFromAttribute<string>(dataElement, "encoding");
            var compression = GetValueFromAttribute<string>(dataElement, "compression");

            var tiledEncoding = TiledEncoding.Base64;
            var tiledCompression = TiledCompression.None;
            var tileGrid = new Grid<uint>(gridSize.X, gridSize.Y);
            var idList = new List<uint>();

            switch (encoding)
            {
                // xml encoding
                case null:
                    tiledEncoding = TiledEncoding.Xml;

                    foreach (var child in dataElement.Children)
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

        public List<TiledProperty> ParseProperties(object data)
        {
            if (data != null)
            {
                var properties = new List<TiledProperty>();
                var propertiesElement = (IElement)data;

                foreach (var property in propertiesElement.Children)
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

        private void ParseDefaultLayerAttributes(IElement xmlElement, ITiledLayer layer)
        {
            // name
            layer.Name = GetValueFromAttribute<string>(xmlElement, "name");

            // size
            layer.Size = GetVec2FromAttributes(xmlElement, "width", "height").ToPoint2();

            // opacity
            var opacityValue = xmlElement?.Attributes.FirstOrDefault(a => a.Name.Equals("opacity"))?.Value;
            var opacity = 1.0f;
            if (opacityValue != null)
                opacity = float.Parse(opacityValue);
            layer.Opacity = opacity;

            // offset
            layer.Offset = GetVec2FromAttributes(xmlElement, "offsetx", "offsety").ToPoint2();

            // properties
            var propertiesElement = xmlElement?.GetElementsByTagName("properties").FirstOrDefault();
            layer.Properties = ParseProperties(propertiesElement);
        }

        private T GetValueFromAttribute<T>(IElement element, string attribute)
        {
            var result = element?.Attributes.FirstOrDefault(a => a.Name.Equals(attribute));
            if (result != null)
                return (T)Convert.ChangeType(result.Value, typeof(T));
            return default(T);
        }

        private Vector2 GetVec2FromAttributes(IElement element, params string[] attributes)
        {
            if (attributes.Length > 2)
                throw new ArgumentException("There should be only two attributes.");

            var valueA = GetValueFromAttribute<float>(element, attributes[0]);
            var valueB = GetValueFromAttribute<float>(element, attributes[1]);
            return new Vector2(valueA, valueB);
        }
    }
}