using UnityEngine;

namespace Script.Monster_Controller
{
    public class MonsterMovementController : MonoBehaviour
    {
        [SerializeField] private float m_movementSpeed = 1f;

        private SpriteRenderer m_spriteRenderer;
        private Rigidbody2D m_monsterRigidbody;
        private Vector2 m_movementDirection;
        
        private Transform m_playerTransformTarget;
        
        private float m_movementSlowEffect = 2f;
        
        private void Awake()
        {
            m_monsterRigidbody = GetComponent<Rigidbody2D>();
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetSlowEffect(float p_slowEffect)
        {
            m_movementSlowEffect = p_slowEffect;
        }
        
        public void SetTarget(Transform p_playerTarget)
        {
            if (m_playerTransformTarget == null)
            {
                m_playerTransformTarget = p_playerTarget;
            }
        }

        private void Update()
        {
            if (m_playerTransformTarget)
            {
                var direction = (m_playerTransformTarget.position - transform.position).normalized;
                m_movementDirection = direction;
                m_spriteRenderer.flipX = m_playerTransformTarget.position.x < transform.position.x;
            }
        }

        private void FixedUpdate()
        {
            if (m_playerTransformTarget)
            {
                m_monsterRigidbody.velocity = m_movementDirection * m_movementSpeed;
            }
        }

        public void ApplyPoisonEffect()
        {
            m_movementSpeed /= m_movementSlowEffect;
        }

        public void ResetPoisonEffect()
        {
            m_movementSpeed *= m_movementSlowEffect;
        }
    }
}
