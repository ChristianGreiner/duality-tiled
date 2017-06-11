using System.Collections.Generic;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public interface ITiledParser<T>
    {
        TiledMap ParseMap(ref ContentRef<TiledMap> contentRef, string inputPath, string file);

        List<ITiledLayer> ParseLayer(ref ContentRef<TiledMap> contentRef, T data);

        List<TiledTileset> ParseTileset(ref ContentRef<TiledMap> contentRef, T data);

        TiledData EncodeData(T data, Point2 gridSize);

        List<TiledProperty> ParseProperties(T data);
    }
}