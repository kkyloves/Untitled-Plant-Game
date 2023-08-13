using System;
using DG.Tweening;
using Script.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI_Controller
{
    public class PlayerExpController : MonoBehaviour
    {
        private const float BASE_MAX_EXP = 100;
        private const float ADDITIONAL_EXP = 20;
        
        [SerializeField] private Image m_levelUpImage;

        private float m_currentMaxExp;
        private float m_currentExp;
        
        private void Awake()
        {
            m_levelUpImage.DOFillAmount(0f, 0f);
            m_currentMaxExp = BASE_MAX_EXP;
        }
        

        public void AddExp()
        {
            m_currentExp += ADDITIONAL_EXP;
            var fillAmount = m_currentExp / m_currentMaxExp;
            
            m_levelUpImage.DOFillAmount(fillAmount, 0.2f).OnComplete(() =>
            {
                if (m_currentExp >= m_currentMaxExp)
                {
                    LevelUpPlayer();
                }
            });
        }

        private void LevelUpPlayer()
        {
            // open level up reward
            GameManager.Instance.UIManager.OpenRewardPanel();
            
            m_currentExp = 0;
            m_currentMaxExp += ADDITIONAL_EXP * 2;
            m_levelUpImage.DOFillAmount(0f, 0.2f);
        }
    }
}
