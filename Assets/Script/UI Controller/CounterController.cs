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
        bool srt;

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

            var minutes = Mathf.FloorToInt(m_timerValue / 60);
            if (minutes < 10)
            {
                m_timerCounterMinutes.text = "0" + minutes.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                m_timerCounterMinutes.text = minutes.ToString(CultureInfo.InvariantCulture);
            }

            var seconds = Mathf.FloorToInt(m_timerValue % 60);
            if (seconds < 10)
            {
                m_timerCounterSeconds.text = "0" + seconds.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                m_timerCounterSeconds.text = seconds.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void Update()
        {
            UpdateFPSCounter();
            UpdateTimer();
        }
    }
}