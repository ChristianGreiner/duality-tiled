using System.Collections.Generic;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Tiled
{
    public class TiledLayer
    {
        /// <summary>
        /// The name of the layer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The x coordinate of the layer in tiles.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The y coordinate of the layer in tiles.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The width of the layer in tiles.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height of the layer in tiles.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The opacity of the layer as a value from 0 to 1. Defaults to 1.
        /// </summary>
        public float Opacity { get; set; }

        /// <summary>
        /// Whether the layer is shown (1) or hidden (0). Defaults to 1.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.
        /// </summary>
        public int OffsetX { get; set; }

        /// <summary>
        /// Rendering offset for this layer in pixels. Defaults to 0.
        /// </summary>
        public int OffsetY { get; set; }

        /// <summary>
        /// The properties of the layer.
        /// </summary>
        public List<TiledProperty> Properties { get; set; }

        /// <summary>
        /// The data of the layer.
        /// </summary>
        public TiledData Data { get; set; }

        public TiledLayer()
        {
            Opacity = 1f;
            Visible = true;
        }
    }
}