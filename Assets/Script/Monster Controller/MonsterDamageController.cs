using System.Collections;
using Script.Managers;
using UnityEngine;

namespace Script.Monster_Controller
{
    public class MonsterDamageController : MonoBehaviour
    {
        private const float TIMER_TO_INFLICT_DAMAGE_TO_PLAYER = 0.3F;
        private const float MONSTER_DAMAGE = 2f;
        private const string PLAYER_TAG = "PlayerCharacter";
        
        private bool m_isCollidedWithThePlayer;
        private MonsterHealthController m_monsterHealthController;
        
        private void Awake()
        {
            m_monsterHealthController = GetComponent<MonsterHealthController>();
        }
        
        private void OnCollisionEnter2D(Collision2D p_collided)
        {
            if (!m_monsterHealthController.IsDead)
            {
                if (p_collided.gameObject.CompareTag(PLAYER_TAG))
                {
                    m_isCollidedWithThePlayer = true;
                    StartCoroutine(InflictDamageToPlayer());
                }
            }
        }

        private void OnCollisionExit2D(Collision2D p_collided)
        {
            if (!m_monsterHealthController.IsDead)
            {
                if (p_collided.gameObject.CompareTag(PLAYER_TAG))
                {
                    m_isCollidedWithThePlayer = false;
                }
            }
        }

        private IEnumerator InflictDamageToPlayer()
        {
            while (m_isCollidedWithThePlayer)
            {
                GameManager.Instance.UIManager.InflictPlayerHealth(MONSTER_DAMAGE);
                yield return new WaitForSeconds(TIMER_TO_INFLICT_DAMAGE_TO_PLAYER);
            }
        }
    }
}
