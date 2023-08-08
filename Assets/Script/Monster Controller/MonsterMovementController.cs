using System;
using UnityEngine;

namespace Script.Monster_Controller
{
    public class MonsterMovementController : MonoBehaviour
    {
        [SerializeField] private Transform m_playerTransform;
        [SerializeField] private float m_movementSpeed;
        
        private Rigidbody2D m_monsterRigidbody;
        private Vector2 m_movementDirection;

        private void Awake()
        {
            m_monsterRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (m_playerTransform)
            {
                var direction = (m_playerTransform.position - transform.position).normalized;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                m_monsterRigidbody.rotation = angle;
                m_movementDirection = direction;
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
