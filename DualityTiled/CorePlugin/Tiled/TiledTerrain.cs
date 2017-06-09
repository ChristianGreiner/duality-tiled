using System.Collections.Generic;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Tiled
{
    public class TiledTerrain
    {
        /// <summary>
        /// The name of the terrain type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The local tile-id of the tile that represents the terrain visually.
        /// </summary>
        public int TileId { get; set; }

        /// <summary>
        /// The properties of the terrain.
        /// </summary>
        public List<TiledProperty> Properties { get; set; }
    }
}