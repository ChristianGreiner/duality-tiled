using System;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Tiled
{
    public struct TiledProperty
    {
        /// <summary>
        /// The name (key) of the property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The data type of the property.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// The value of the property.
        /// </summary>
        public object Value { get; }

        public TiledProperty(string name, Type type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}