using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Player_Controller
{
    public class PlayerHealthController : MonoBehaviour
    {
        private const float PLAYER_BASE_HEALTH = 100f;

        [SerializeField] private Image m_playerHealthBar;
        
        private float m_playerCurrentHealth;
        private float m_maxPlayerHealth;

        private void Awake()
        {
            m_maxPlayerHealth = PLAYER_BASE_HEALTH;
            m_playerCurrentHealth = m_maxPlayerHealth;
            m_playerHealthBar.DOFillAmount(m_playerCurrentHealth, 0f);
            
            //InvokeRepeating(nameof(HealPlayerHealth), 0f, 0.5f);
        }

        public void InflictPlayerHealth(float p_damage)
        {
            m_playerCurrentHealth -= p_damage;
            UpdatePlayerHealthBar();
        }

        public void HealPlayerHealth(float p_healAmount)
        {
            m_playerCurrentHealth += p_healAmount;
            if (m_playerCurrentHealth >= PLAYER_BASE_HEALTH)
            {
                m_playerCurrentHealth = PLAYER_BASE_HEALTH;
            }
            
            UpdatePlayerHealthBar();
        }

        private void UpdatePlayerHealthBar()
        {
            var fillAmount = m_playerCurrentHealth / m_maxPlayerHealth;
            m_playerHealthBar.DOFillAmount(fillAmount, 0.3f);
        }
    }
}
