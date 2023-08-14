using System;
using Script.Managers;
using Script.Player_Controller;
using Script.Rewards_Controller;
using Script.Scriptable_Object;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI_Controller
{
    public class RewardPanelItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_rewardDetails;
        [SerializeField] private Button m_rewardButton;

        private RewardEffect m_rewardEffect;
        private RewardItemDetails m_currentRewardItemDetails;
        
        private int m_rewardListIndex;
        
        private void Awake()
        {
            m_rewardButton.onClick.AddListener(AddRewardButtonListener);
        }
        
        public void Init(RewardItemDetails p_rewardItemDetails, int p_rewardListIndex)
        {
            m_rewardListIndex = p_rewardListIndex;
            m_currentRewardItemDetails = p_rewardItemDetails;
            m_rewardEffect = m_currentRewardItemDetails.RewardEffect;
            m_rewardDetails.text = m_currentRewardItemDetails.RewardMessage;
        }

        private void AddRewardButtonListener()
        {
            switch (m_rewardEffect)
            {
                case RewardEffect.AddLootChance:
                {
                    GameManager.Instance.RewardEffectManager.AddLootChance(m_currentRewardItemDetails.LootItemDetails.LootId);
                }
                    break;
                case RewardEffect.MoveSpeed:
                {
                    GameManager.Instance.RewardEffectManager.AddMoveSpeed();
                    GameManager.Instance.RewardEffectManager.UpdatePlayer(GameManager.Instance.PlayerGeneralController);
                }
                    break;
                case RewardEffect.Projectile:
                {
                    GameManager.Instance.RewardEffectManager.TurnOnProjectileEffect();
                }
                    break;
                case RewardEffect.AllAddDamage:
                {
                    GameManager.Instance.RewardEffectManager.AddPoisonDamage();
                    GameManager.Instance.RewardEffectManager.AddSquashBulletDamage();
                }
                    break;
                case RewardEffect.AddDamageSquash:
                {
                    GameManager.Instance.RewardEffectManager.AddSquashBulletDamage();
                }
                    break;
                case RewardEffect.AddDamageMushroom:
                {
                    GameManager.Instance.RewardEffectManager.AddPoisonDamage();
                }
                    break;
                case RewardEffect.AddPoisonRange:
                {
                    GameManager.Instance.RewardEffectManager.AddPoisonRange();
                }
                    break;
                case RewardEffect.FasterFireRate:
                {
                    GameManager.Instance.RewardEffectManager.MakeShootTimerFaster();
                }
                    break;
                case RewardEffect.GiveMoreHealth:
                {
                    GameManager.Instance.RewardEffectManager.AddHealEffect();
                }
                    break;
                case RewardEffect.PlantFaster:
                {
                    GameManager.Instance.RewardEffectManager.AddPlantSpeed();
                    GameManager.Instance.RewardEffectManager.UpdatePlayer(GameManager.Instance.PlayerGeneralController);
                }
                    break;
                case RewardEffect.SlowerPoison:
                {
                    GameManager.Instance.RewardEffectManager.AddSlowPoison();
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(m_rewardEffect), m_rewardEffect, null);
            }
            
            GameManager.Instance.UIManager.AddRewardsAcquiredCount();
            GameManager.Instance.UIManager.CloseRewardPanel(m_rewardListIndex);
        }
    }
}
