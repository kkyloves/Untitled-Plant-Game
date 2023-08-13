using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.UI_Controller
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button m_playButton;
        [SerializeField] private Button m_quitButton;

        private void Awake()
        {
            m_playButton.onClick.AddListener(OnClickPlayButton);
            m_quitButton.onClick.AddListener(OnClickQuitButton);
        }

        private void OnClickPlayButton()
        {
            SceneManager.LoadScene("Game Scene");
        }

        private void OnClickQuitButton()
        {
            Application.Quit();
        }
    }
}
