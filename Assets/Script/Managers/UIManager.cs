using Script.Player_Controller;
using Script.Rewards_Controller;
using Script.Scriptable_Object;
using Script.UI_Controller;
using UnityEngine;

namespace Script.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private PlayerHealthController m_playerHealthController;
        [SerializeField] private PlayerExpController m_playerExpController;
        [SerializeField] private RewardPanelController m_rewardPanelController;
        [SerializeField] private PlayerSeedContainerController m_playerSeedContainerController;
        [SerializeField] private ResultPanelController m_resultPanelController;
        [SerializeField] private CounterController m_counterController;

        public void HealPlayerHealth(float p_healAmount)
        {
            m_playerHealthController.HealPlayerHealth(p_healAmount);
        }
        
        public void InflictPlayerHealth(float p_damage)
        {
            m_playerHealthController.InflictPlayerHealth(p_damage);
        }

        public void AddExp()
        {
            m_playerExpController.AddExp();
        }

        public void OpenRewardPanel()
        {
            m_rewardPanelController.OpenRewardPanel();
        }
        
        public void CloseRewardPanel(int p_index)
        {
            m_rewardPanelController.RemoveReward(p_index);
            m_rewardPanelController.CloseRewardPanel();
        }
        
        public void UpdateSeedCount(PlantSkill p_plantSkill, int p_seedCount)
        {
            m_playerSeedContainerController.UpdateSeedCount(p_plantSkill, p_seedCount);
        }

        public void OpenResultPanel()
        {
            m_resultPanelController.OpenResultPanel();
        }

        public void AddChickenKilledCount()
        {
            m_resultPanelController.AddChickenKilledCount();
        }
        
        public void AddRewardsAcquiredCount()
        {
            m_resultPanelController.AddRewardsAcquiredCount();
        }

        public int GetCurrentMinuteTimerCount()
        {
            return m_counterController.CurrentMinutes;
        }
        
        public int GetCurrentSecondsTimerCount()
        {
            return m_counterController.CurrentSeconds;
        }
    }
    
}
