using System.Collections.Generic;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Tiled
{
    public class TiledTileset
    {
        /// <summary>
        /// The first global tile ID of this tileset (this global ID maps to the first tile in this tileset).
        /// </summary>
        public int FirstGid { get; set; }

        /// <summary>
        /// The name of this tileset.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The (maximum) width of the tiles in this tileset.
        /// </summary>
        public int TileWidth { get; set; }

        /// <summary>
        /// The (maximum) height of the tiles in this tileset.
        /// </summary>
        public int TileHeight { get; set; }

        /// <summary>
        /// The spacing in pixels between the tiles in this tileset (applies to the tileset image).
        /// </summary>
        public int Spacing { get; set; }

        /// <summary>
        /// The margin around the tiles in this tileset (applies to the tileset image).
        /// </summary>
        public int Margin { get; set; }

        /// <summary>
        /// The number of tiles in this tileset.
        /// </summary>
        public int TileCount { get; set; }

        /// <summary>
        /// The number of tile columns in the tileset. For image collection tilesets it is editable and is used when displaying the tileset.
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// This element is used to specify an offset in pixels, to be applied when drawing a tile from the related tileset. When not present, no offset is applied.
        /// </summary>
        public TiledTileoffset Tileoffset { get; set; }

        /// <summary>
        /// The properties of the tileset.
        /// </summary>
        public List<TiledProperty> Properties { get; set; }

        // TODO: Image, Terraintypes, Tile
    }
}