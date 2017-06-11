using System.Collections.Generic;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public interface ITiledParser<T>
    {
        ContentRef<TiledMap> Tilemap { get; }

        string RawData { get; }

        string InputPath { get; }

        void Parse();

        List<TiledTileset> ParseTilesets(T data);

        List<ITiledLayer> ParseTiledLayers(T data);

        TiledLayer ParseTiledLayer(T data);

        TiledObjectgroup ParseObjectgroup(T data);

        TiledObject ParseTiledObject(T data);

        List<TiledProperty> ParseProperties(T data);
    }
}