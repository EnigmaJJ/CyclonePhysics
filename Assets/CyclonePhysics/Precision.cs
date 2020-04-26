namespace Cyclone
{
    public static class Precision
    {
    #if SINGLE_PRECISION
        public static float RealSqrt(float x)
        {
            return (float)System.Math.Sqrt(x);
        }
    #else
        public static double RealSqrt(double x)
        {
            return System.Math.Sqrt(x);
        }
    #endif
    }
}
