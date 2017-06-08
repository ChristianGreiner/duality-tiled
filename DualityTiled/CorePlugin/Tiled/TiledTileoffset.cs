using System.Collections.Generic;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Tiled
{
    /// <summary>
    /// This element is used to specify an offset in pixels, to be applied when drawing a tile from the related tileset. When not present, no offset is applied.
    /// </summary>
    public struct TiledTileoffset
    {
        /// <summary>
        /// Horizontal offset in pixels.
        /// </summary>
        public int X { get; }

        /// <summary>
        ///  Vertical offset in pixels (positive is down).
        /// </summary>
        public int Y { get; }

        public TiledTileoffset(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}