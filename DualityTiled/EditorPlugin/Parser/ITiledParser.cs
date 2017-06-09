using System.Collections.Generic;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public interface ITiledParser
    {
        TiledMap ParseMap(object data);

        List<ITiledLayer> ParseLayer(object data);

        List<TiledProperty> ParseProperties(object data);
    }
}