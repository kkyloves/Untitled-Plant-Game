using UnityEngine;
using UnityEngine.InputSystem;

namespace Script.Player_Controller
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float m_playerMovementSpeed = 5f;
        
        private Rigidbody2D m_playerRigidbody;
        private Vector2 m_movementInput;
        
        private PlayerAnimationController m_playerAnimationController;

        private void Awake()
        {
            m_playerRigidbody = GetComponent<Rigidbody2D>();
            m_playerAnimationController = GetComponent<PlayerAnimationController>();
        }

        public void SetMovementSpeed(float p_speed)
        {
            m_playerMovementSpeed = p_speed;
        }

        private void Update()
        {
            var horizontalValue = m_movementInput.x;
            var verticalValue = m_movementInput.y;
            var speedValue = m_movementInput.sqrMagnitude;
            
            m_playerAnimationController.PlayMovementAnimation(horizontalValue, verticalValue, speedValue);
        }

        private void FixedUpdate()
        {
            //m_playerRigidbody.MovePosition(m_playerRigidbody.position + m_movementInput * m_playerMovementSpeed * Time.fixedDeltaTime);
            m_playerRigidbody.velocity = m_movementInput * m_playerMovementSpeed;
        }

        private void OnMove(InputValue p_inputValue)
        {
            m_movementInput = p_inputValue.Get<Vector2>();
        }
    }
}
