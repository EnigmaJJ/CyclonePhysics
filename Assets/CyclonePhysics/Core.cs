#if SINGLE_PRECISION
    using Real = System.Single;
#else
    using Real = System.Double;
#endif

namespace Cyclone
{
    public class Vector3
    {
        #region Variables
        public Real x;
        public Real y;
        public Real z;
        #endregion
    }
}
