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
                    RewardEffectController.Instance.AddLootChance(m_currentRewardItemDetails.LootItemDetails.LootId);
                }
                    break;
                case RewardEffect.MoveSpeed:
                {
                    RewardEffectController.Instance.AddMoveSpeed();
                    RewardEffectController.Instance.UpdatePlayer(PlayerGeneralController.Instance);
                }
                    break;
                case RewardEffect.Projectile:
                {
                    RewardEffectController.Instance.TurnOnProjectileEffect();
                }
                    break;
                case RewardEffect.AllAddDamage:
                {
                    RewardEffectController.Instance.AddPoisonDamage();
                    RewardEffectController.Instance.AddSquashBulletDamage();
                }
                    break;
                case RewardEffect.AddDamageSquash:
                {
                    RewardEffectController.Instance.AddSquashBulletDamage();
                }
                    break;
                case RewardEffect.AddDamageMushroom:
                {
                    RewardEffectController.Instance.AddPoisonDamage();
                }
                    break;
                case RewardEffect.AddPoisonRange:
                {
                    RewardEffectController.Instance.AddPoisonRange();
                }
                    break;
                case RewardEffect.FasterFireRate:
                {
                    RewardEffectController.Instance.MakeShootTimerFaster();
                }
                    break;
                case RewardEffect.GiveMoreHealth:
                {
                    RewardEffectController.Instance.AddHealEffect();
                }
                    break;
                case RewardEffect.PlantFaster:
                {
                    RewardEffectController.Instance.AddPlantSpeed();
                    RewardEffectController.Instance.UpdatePlayer(PlayerGeneralController.Instance);
                }
                    break;
                case RewardEffect.SlowerPoison:
                {
                    RewardEffectController.Instance.AddSlowPoison();
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(m_rewardEffect), m_rewardEffect, null);
            }
            
            UIManager.Instance.CloseRewardPanel(m_rewardListIndex);
        }
    }
}
