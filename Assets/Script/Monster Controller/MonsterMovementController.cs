using UnityEngine;

namespace Script.Monster_Controller
{
    public class MonsterMovementController : MonoBehaviour
    {
        [SerializeField] private Transform m_playerTransform;
        [SerializeField] private float m_movementSpeed;

        private SpriteRenderer m_spriteRenderer;
        private Rigidbody2D m_monsterRigidbody;
        private Vector2 m_movementDirection;

        private void Awake()
        {
            m_monsterRigidbody = GetComponent<Rigidbody2D>();
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (m_playerTransform)
            {
                var direction = (m_playerTransform.position - transform.position).normalized;
                m_movementDirection = direction;
                m_spriteRenderer.flipX = m_playerTransform.position.x < transform.position.x;
            }
        }

        private void FixedUpdate()
        {
            if (m_playerTransform)
            {
                m_monsterRigidbody.velocity = m_movementDirection * m_movementSpeed;
            }
        }
    }
}
