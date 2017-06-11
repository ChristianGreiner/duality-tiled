namespace ChristianGreiner.Duality.Plugins.DualityTiled.Parser
{
    public class TiledParser<T>
    {
        public T Source { get; set; }

        public TiledParser()
        {
        }

        public TiledParser(T source)
        {
            Source = source;
        }
    }
}