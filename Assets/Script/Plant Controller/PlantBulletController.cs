using Script.Monster_Controller;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantBulletController : MonoBehaviour
    {
        private const float BULLET_SPEED = 10f;
        private Rigidbody2D m_rigidbody2D;
        
        private bool m_isDeployed;
        public bool IsDeployed => m_isDeployed;


        private void Awake()
        {
            m_rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Init(Vector3 p_targetMonster, Vector2 p_position)
        {
            m_isDeployed = true;
            
            transform.position = new Vector2(p_position.x, p_position.y);
            gameObject.SetActive(true);
            
            var direction = (p_targetMonster - transform.position).normalized;
            m_rigidbody2D.AddForce(direction * BULLET_SPEED, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D p_collided)
        {
            if (p_collided.CompareTag("Monster"))
            {
                p_collided.GetComponent<MonsterHealthController>().DamageMonster(30f, false);
                Disappear();
            }
            
            if(p_collided.CompareTag("Border"))
            {
                Disappear();
            }
        }

        private void Disappear()
        {
            m_isDeployed = false;
            gameObject.SetActive(false);
        }
    }
}
