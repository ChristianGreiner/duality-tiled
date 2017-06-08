using System.Collections.Generic;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Tiled
{
    public struct TiledTile
    {
        /// <summary>
        /// The local tile ID within its tileset.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The properties of the tile.
        /// </summary>
        public List<TiledProperty> Properties { get; }

        public TiledTile(int id, List<TiledProperty> properties)
        {
            Id = id;
            Properties = properties;
        }

        // TODO: Terrain, probability
    }
}