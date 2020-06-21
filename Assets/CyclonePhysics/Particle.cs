using UnityEngine.Assertions;

#if SINGLE_PRECISION
    using Real = System.Single;
#else
    using Real = System.Double;
#endif

namespace Cyclone
{
    public class Particle
    {
        #region Variables
        /// <summary>
        /// Holds the amount of damping applied to linear
        /// motion. Damping is required to remove energy added
        /// through numerical instability in the integrator.
        /// </summary>
        protected Real _damping;

        /// <summary>
        /// 质量的倒数
        /// </summary>
        protected Real _inverseMass;
        
        /// <summary>
        /// 世界坐标系下的位置
        /// </summary>
        protected Vector3 _position;

        /// <summary>
        /// 速度
        /// </summary>
        protected Vector3 _velocity;

        /// <summary>
        /// 加速度
        /// </summary>
        protected Vector3 _acceleration;

        /// <summary>
        /// Holds the accumulated force to be applied at the next
        /// simulation iteration only. This value is zeroed at each
        /// integration step.
        /// </summary>
        protected Vector3 _forceAccum;
        #endregion

        #region Methods
        public void Integrate(Real duration)
        {
            if (_inverseMass <= 0)
            {
                return;
            }
            
            Assert.IsTrue(duration > 0);
            
            // Update linear position.
            _position.AddScaledVector(_velocity, duration);

            Vector3 resultingAcc = _acceleration;
            resultingAcc.AddScaledVector(_forceAccum, _inverseMass);
            
            // Update linear velocity from the acceleration.
            _velocity.AddScaledVector(resultingAcc, duration);
        }
        
        /// <summary>
        /// 设置质量
        /// @warning This invalidates internal data for the particle.
        /// Either an integration function, or the calculateInternals
        /// function should be called before trying to get any settings
        /// from the particle.
        /// </summary>
        /// <param name="mass"></param>
        public void SetMass(Real mass)
        {
            Assert.IsFalse(Precision.RealApproximately(mass, 0));
            _inverseMass = ((Real)1) / mass;
        }

        /// <summary>
        /// 课题研究目标、研究内容和拟解决的关键性问题
        /// 
        /// </summary>
        /// <returns></returns>
        public Real GetMass()
        {
            if (Precision.RealApproximately(_inverseMass, 0))
            {
                return Precision.REAL_MAX;
            }
            
            return ((Real)1) / _inverseMass;
        }

        public void SetInverseMass(Real inverseMass)
        {
            _inverseMass = inverseMass;
        }

        public Real GetInverseMass()
        {
            return _inverseMass;
        }
        #endregion
    }
}
