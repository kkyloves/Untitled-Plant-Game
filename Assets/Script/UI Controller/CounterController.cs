using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace Script.UI_Controller
{
    public class CounterController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_fpsCounter;
        [SerializeField] private TextMeshProUGUI m_timerCounterMinutes;
        [SerializeField] private TextMeshProUGUI m_timerCounterSeconds;

        private float m_fpsUpdateTimer = 0.2f;
        private float m_currentFps;
        private float m_timerValue;

        private int m_currentMinutes;
        public int CurrentMinutes => m_currentMinutes;
        
        private int m_currentSeconds;
        public int CurrentSeconds => m_currentSeconds;
        
        private void UpdateFPSCounter()
        {
            m_fpsUpdateTimer -= Time.deltaTime;
            if (m_fpsUpdateTimer <= 0f)
            {
                m_currentFps = 1f / Time.unscaledDeltaTime;
                m_fpsCounter.text = "FPS: " + Mathf.Round(m_currentFps);
                m_fpsUpdateTimer = 0.2f;
            }
        }

        private void UpdateTimer()
        {
            m_timerValue += Time.deltaTime;

            m_currentMinutes = Mathf.FloorToInt(m_timerValue / 60);
            if (m_currentMinutes < 10)
            {
                m_timerCounterMinutes.text = "0" + m_currentMinutes.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                m_timerCounterMinutes.text = m_currentMinutes.ToString(CultureInfo.InvariantCulture);
            }

            m_currentSeconds = Mathf.FloorToInt(m_timerValue % 60);
            if (m_currentSeconds < 10)
            {
                m_timerCounterSeconds.text = "0" + m_currentSeconds.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                m_timerCounterSeconds.text = m_currentSeconds.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void Update()
        {
            UpdateFPSCounter();
            UpdateTimer();
        }
    }
}