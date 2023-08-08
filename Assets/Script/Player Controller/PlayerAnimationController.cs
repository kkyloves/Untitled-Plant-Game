using System;
using UnityEngine;

namespace Script.Player_Controller
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator m_playerAnimator;
        private static readonly int PlayerHorizontal = Animator.StringToHash("PlayerHorizontal");
        private static readonly int PlayerVertical = Animator.StringToHash("PlayerVertical");
        private static readonly int PlayerSpeed = Animator.StringToHash("PlayerSpeed");

        private void Awake()
        {
            m_playerAnimator = GetComponent<Animator>();
        }

        public void PlayAnimation(float p_playerHorizontalValue, float p_playerVerticalValue, float p_playerSpeed)
        {
            m_playerAnimator.SetFloat(PlayerHorizontal, p_playerHorizontalValue);
            m_playerAnimator.SetFloat(PlayerVertical, p_playerVerticalValue);
            m_playerAnimator.SetFloat(PlayerSpeed, p_playerSpeed);
        }
    }
}
