using System.Collections.Generic;
using Duality;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Tiled
{
    public class TiledPolygon : TiledObject
    {
        /// <summary>
        /// A list of x and y coordinates.
        /// </summary>
        public List<Vector2> Points { get; set; }
    }
}