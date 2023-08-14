using System.Globalization;
using Script.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.UI_Controller
{
    public class ResultPanelController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_survivedMinutesText;
        [SerializeField] private TextMeshProUGUI m_survivedSecondsText;
        [SerializeField] private TextMeshProUGUI m_killedChickenText;
        [SerializeField] private TextMeshProUGUI m_rewardAcquiredText;
        [SerializeField] private Button m_playAgainButton;

        private int m_totalChickenKilled;
        private int m_totalRewardsAcquired;

        private void Awake()
        {
            m_playAgainButton.onClick.AddListener(OnClickPlayAgain);
        }

        private void OnClickPlayAgain()
        {
            SceneManager.LoadScene("Game Scene");
        }

        public void AddChickenKilledCount()
        {
            m_totalChickenKilled++;
        }

        public void AddRewardsAcquiredCount()
        {
            m_totalRewardsAcquired++;
        }

        public void OpenResultPanel()
        {
            if (m_totalChickenKilled <= 1)
            {
                m_killedChickenText.text = m_totalChickenKilled + " CHICKEN!";
            }
            else
            {
                m_killedChickenText.text = m_totalChickenKilled + " CHICKENS!";
            }
            
            if (m_totalRewardsAcquired <= 1)
            {
                m_rewardAcquiredText.text = m_totalRewardsAcquired + " REWARD!";
            }
            else
            {
                m_rewardAcquiredText.text = m_totalRewardsAcquired + " REWARDS!";
            }
            
            var minutes = GameManager.Instance.UIManager.GetCurrentMinuteTimerCount();
            var seconds = GameManager.Instance.UIManager.GetCurrentSecondsTimerCount();
            
            if (minutes < 10)
            {
                m_survivedMinutesText.text = "0" + minutes.ToString(CultureInfo.InvariantCulture) + "M";
            }
            else
            {
                m_survivedMinutesText.text = minutes.ToString(CultureInfo.InvariantCulture) + "M";
            }
            
            if (seconds < 10)
            {
                m_survivedSecondsText.text = "0" + seconds.ToString(CultureInfo.InvariantCulture) + "S";
            }
            else
            {
                m_survivedSecondsText.text = seconds.ToString(CultureInfo.InvariantCulture) + "S";
            }

            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
