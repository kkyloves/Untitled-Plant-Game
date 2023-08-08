using System.Collections;
using Script.Player_Controller;
using UnityEngine;

namespace Script.Monster_Controller
{
    public class MonsterDamageController : MonoBehaviour
    {
        private const float TIMER_TO_INFLICT_DAMAGE_TO_PLAYER = 0.3F;
        private const string PLAYER_TAG = "PlayerCharacter";

        [SerializeField] private PlayerHealthController m_playerHealthController;

        private float m_monsterDamage = 5f;
        private bool m_isCollidedWithThePlayer;
        
        private void OnCollisionEnter2D(Collision2D p_collided)
        {
            if (p_collided.gameObject.CompareTag(PLAYER_TAG))
            {
                m_isCollidedWithThePlayer = true;
                StartCoroutine(InflictDamageToPlayer());
            }
        }

        private void OnCollisionExit2D(Collision2D p_collided)
        {
            if (p_collided.gameObject.CompareTag(PLAYER_TAG))
            {
                m_isCollidedWithThePlayer = false;
            }
        }

        private IEnumerator InflictDamageToPlayer()
        {
            while (m_isCollidedWithThePlayer)
            {
                m_playerHealthController.InflictPlayerHealth(m_monsterDamage);
                yield return new WaitForSeconds(TIMER_TO_INFLICT_DAMAGE_TO_PLAYER);
            }
        }
    }
}
