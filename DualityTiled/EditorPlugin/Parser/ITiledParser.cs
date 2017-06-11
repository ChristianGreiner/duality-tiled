using System.Collections.Generic;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public interface ITiledParser<T>
    {
        TiledMap ParseMap(ref ContentRef<TiledMap> contentRef, object data);

        List<ITiledLayer> ParseLayer(ref ContentRef<TiledMap> contentRef, object data);

        List<TiledTileset> ParseTileset(ref ContentRef<TiledMap> contentRef, object data);

        TiledData EncodeData(object data, Point2 gridSize);

        List<TiledProperty> ParseProperties(object data);
    }
}