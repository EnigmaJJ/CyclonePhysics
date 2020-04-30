namespace Cyclone
{
    public static class Precision
    {
    #if SINGLE_PRECISION
        public static float REAL_MAX = float.MaxValue;
        
        public static float RealSqrt(float x)
        {
            return (float)System.Math.Sqrt(x);
        }

        public static bool RealApproximately(float a, float b)
        {
            return (System.Math.Abs(a - b) <= System.Single.Epsilon);
        }
    #else
        public static double REAL_MAX = double.MaxValue;
    
        public static double RealSqrt(double x)
        {
            return System.Math.Sqrt(x);
        }
        
        public static bool RealApproximately(double a, double b)
        {
            return (System.Math.Abs(a - b) <= System.Double.Epsilon);
        }
    #endif
    }
}
