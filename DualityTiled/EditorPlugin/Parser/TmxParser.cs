using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Parser.Xml;
using ChristianGreiner.Duality.Plugins.DualityTiled.Misc;
using ChristianGreiner.Duality.Plugins.DualityTiled.Tiled;
using Duality;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public class TmxParser : ITiledParser
    {
        public TiledMap ParseMap(object data)
        {
            var xmlParser = new XmlParser();
            var xmlDocument = xmlParser.Parse((string)data);
            TiledMap map = new TiledMap();

            var mapElement = xmlDocument.GetElementsByTagName("map").FirstOrDefault();

            var mapSize = GetVec2FromAttributes(mapElement, "width", "height").ToPoint2();
            map.Size = mapSize;

            return map;
        }

        public List<ITiledLayer> ParseLayer(object data)
        {
            throw new System.NotImplementedException();
        }

        public List<TiledProperty> ParseProperties(object data)
        {
            throw new System.NotImplementedException();
        }

        private T GetValueFromAttribute<T>(IElement element, string attribute)
        {
            var result = element?.Attributes.FirstOrDefault(a => a.Name.Equals(attribute));
            if (result != null)
                return (T)Convert.ChangeType(result.Value, typeof(T));
            return default(T);
        }

        private Vector2 GetVec2FromAttributes(IElement element, params string[] attributes)
        {
            if (attributes.Length > 2)
                throw new ArgumentException("There should be only two attributes.");

            var valueA = GetValueFromAttribute<float>(element, attributes[0]);
            var valueB = GetValueFromAttribute<float>(element, attributes[1]);
            return new Vector2(valueA, valueB);
        }
    }
}