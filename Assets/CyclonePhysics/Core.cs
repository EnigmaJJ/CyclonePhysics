#if SINGLE_PRECISION
    using Real = System.Single;
#else
    using Real = System.Double;
#endif

namespace Cyclone
{
    public struct Vector3
    {
        #region Variables
        public Real x;
        public Real y;
        public Real z;
        #endregion

        #region Methods
        public Vector3(Real x, Real y, Real z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        
        public static Vector3 operator *(Vector3 vector, Real value)
        {
            return new Vector3(vector.x * value, vector.y * value, vector.z * value);
        }

        public static Vector3 operator *(Real value, Vector3 vector)
        {
            return (vector * value);
        }

        public static Real operator *(Vector3 a, Vector3 b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z);
        }

        public static Vector3 operator %(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - a.z * b.y
                             , a.z * b.x - a.x * b.z
                             , a.x * b.y - a.y * b.x);
        }

        public Vector3 ComponentProduct(Vector3 vector)
        {
            return new Vector3(x * vector.x, y * vector.y, z * vector.z);
        }

        public void ComponentProductUpdate(Vector3 vector)
        {
            x *= vector.x;
            y *= vector.y;
            z *= vector.z;
        }

        public Vector3 VectorProduct(Vector3 vector)
        {
            return (this % vector);
        }

        public Real ScalarProduct(Vector3 vector)
        {
            return (this * vector);
        }

        public void AddScaledVector(Vector3 vector, Real scale)
        {
            x += (vector.x * scale);
            y += (vector.y * scale);
            z += (vector.z * scale);
        }

        public Real Magnitude()
        {
            return Precision.RealSqrt(x * x + y * y + z * z);
        }

        public Real SquareMagnitude()
        {
            return (x * x + y * y + z * z);
        }

        public void Normalize()
        {
            Real l = Magnitude();
            if (l > 0)
            {
                
            }
        }

        public void Invert()
        {
            x = -x;
            y = -y;
            z = -z;
        }
        #endregion
    }
}
