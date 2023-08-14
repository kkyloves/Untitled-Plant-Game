using System.Collections.Generic;
using Script.Managers;
using Script.Scriptable_Object;
using UnityEngine;

namespace Script.UI_Controller
{
    public class RewardPanelController : MonoBehaviour
    {
        [SerializeField] private List<RewardItemDetails> m_rewardItemDetailsArray;
        [SerializeField] private RewardPanelItem[] m_rewardPanelItems;

        public void OpenRewardPanel()
        {
            if (m_rewardItemDetailsArray.Count > 0)
            {
                for (var i = 0; i < m_rewardPanelItems.Length; i++)
                {
                    var reward = m_rewardPanelItems[i];

                    if (m_rewardItemDetailsArray.Count > 0)
                    {
                        var random = Random.Range(0, m_rewardItemDetailsArray.Count);
                        reward.Init(m_rewardItemDetailsArray[random], i);

                        reward.gameObject.SetActive(true);
                    }
                    else
                    {
                        reward.gameObject.SetActive(false);
                    }
                }

                gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        public void RemoveReward(int p_index)
        {
            m_rewardItemDetailsArray.RemoveAt(p_index);
        }

        public void CloseRewardPanel()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}