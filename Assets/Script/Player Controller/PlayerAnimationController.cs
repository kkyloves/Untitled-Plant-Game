using UnityEngine;

namespace Script.Player_Controller
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator m_playerAnimator;
        
        private static readonly int PlayerHorizontal = Animator.StringToHash("PlayerHorizontal");
        private static readonly int PlayerVertical = Animator.StringToHash("PlayerVertical");
        private static readonly int PlayerSpeed = Animator.StringToHash("PlayerSpeed");
        private static readonly int PlayerPlanting = Animator.StringToHash("PlayerPlanting");
        private static readonly int StopPlanting = Animator.StringToHash("StopPlanting");

        private float m_plantAnimationSpeed = 1f;
        private static readonly int PlayerPlantSpeed = Animator.StringToHash("PlayerPlantSpeed");
        
        private void Awake()
        {
            m_playerAnimator = GetComponent<Animator>();
        }

        public void PlayMovementAnimation(float p_playerHorizontalValue, float p_playerVerticalValue, float p_playerSpeed)
        {
            m_playerAnimator.SetFloat(PlayerHorizontal, p_playerHorizontalValue);
            m_playerAnimator.SetFloat(PlayerVertical, p_playerVerticalValue);
            m_playerAnimator.SetFloat(PlayerSpeed, p_playerSpeed);
        }

        public void PlayPlantingAnimation()
        {
            m_playerAnimator.SetTrigger(PlayerPlanting);
        }
        
        public void ResetPlantingAnimation()
        {
            m_playerAnimator.SetTrigger(StopPlanting);
        }

        public void SetPlayerPlantAnimationSpeed(float p_plantAnimationSpeed)
        {
            m_plantAnimationSpeed = p_plantAnimationSpeed;
            m_playerAnimator.SetFloat(PlayerPlantSpeed, m_plantAnimationSpeed);
        }
    }
}
