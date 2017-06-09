using Duality;

namespace ChristianGreiner.Duality.Plugins.DualityTiled.Misc
{
    public static class ExtensionMethods
    {
        public static Point2 ToPoint2(this Vector2 v)
        {
            return new Point2(MathF.RoundToInt(v.X), MathF.RoundToInt(v.Y));
        }
    }
}