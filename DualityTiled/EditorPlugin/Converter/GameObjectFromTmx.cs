using System;
using System.Collections.Generic;
using System.Linq;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;
using Duality.Components;
using Duality.Drawing;
using Duality.Editor;
using Duality.Editor.Plugins.Tilemaps;
using Duality.Plugins.Tilemaps;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Converter
{
    public class GameObjectFromTmx : DataConverter
    {
        public override Type TargetType
        {
            get { return typeof(GameObject); }
        }

        public override bool CanConvertFrom(ConvertOperation convert)
        {
            return
                convert.AllowedOperations.HasFlag(ConvertOperation.Operation.CreateObj) &&
                convert.CanPerform<TiledMap>();
        }

        public override bool Convert(ConvertOperation convert)
        {
            List<object> results = new List<object>();
            var data = convert.Perform<TiledMap>().ToList();

            foreach (var tiledMap in data)
            {
                if (convert.IsObjectHandled(tiledMap)) continue;

                GameObject rootObj = null;
                rootObj = convert.Result.OfType<GameObject>().FirstOrDefault();

                if (rootObj == null)
                {
                    rootObj = new GameObject(tiledMap.Name);
                    var transform = rootObj.AddComponent<Transform>();
                    int layerId = 0;

                    foreach (var layer in tiledMap.Layer)
                    {
                        layerId++;

                        var layerType = layer.GetType();
                        var layerGameObj = new GameObject("[" + layerId + "] " + layer.Name, rootObj);
                        layerGameObj.AddComponent<Transform>();
                        layerGameObj.Transform.Pos = Vector3.Zero;

                        if (layerType == typeof(TiledLayer) && tiledMap.Tilesets != null)
                        {
                            var dataLayer = (TiledLayer)layer;
                            var tilemap = layerGameObj.AddComponent<Tilemap>();
                            var renderer = layerGameObj.AddComponent<TilemapRenderer>();

                            renderer.Origin = Alignment.TopLeft;
                            renderer.ColorTint = new ColorRgba(255, 255, 255, dataLayer.Opacity);

                            TilemapsSetupUtility.SetupTilemap(tilemap, tiledMap.Tilesets[0].Tileset, dataLayer.Size.X, dataLayer.Size.Y, false);

                            for (int y = 0; y < dataLayer.Size.Y; y++)
                            {
                                for (int x = 0; x < dataLayer.Size.X; x++)
                                {
                                    var tile = dataLayer.Data.Tiles[x, y];

                                    if (tile != 0)
                                        tilemap.SetTile(x, y, new Tile((int)tile - 1));
                                    else
                                        tilemap.SetTile(x, y, new Tile(0));
                                }
                            }
                        }
                    }

                    results.Add(rootObj);
                    convert.AddResult(results);
                    convert.MarkObjectHandled(transform);
                }
            }

            return false;
        }
    }
}