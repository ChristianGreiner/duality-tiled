using System;
using System.IO;
using Ionic.Zlib;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Misc
{
    public static class TiledDecoder
    {
        public static Stream Decode(string data)
        {
            return new MemoryStream(Convert.FromBase64String(data), false);
        }

        public static Stream DecodeZlib(string data)
        {
            byte[] buffer = Convert.FromBase64String(data);
            MemoryStream comp = new MemoryStream(buffer);
            return new ZlibStream(comp, CompressionMode.Decompress);
        }

        public static Stream DecodeGzip(string data)
        {
            return new GZipStream(Decode(data), CompressionMode.Decompress);
        }
    }
}