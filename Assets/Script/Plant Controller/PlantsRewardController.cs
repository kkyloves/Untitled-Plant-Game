using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantsRewardController : MonoBehaviour
    {
        private float m_canShootTimer = 0.5f;
        private bool m_isProjectile;

        private float m_totalAdditionalDamage;
        
        public void TurnOnProjectileEffect()
        {
            m_isProjectile = true;
        }

        public void MakeShootTimerFaster()
        {
            m_canShootTimer -= 0.1f;
        }

        public void AddDamages()
        {
            
        }
    }
}
