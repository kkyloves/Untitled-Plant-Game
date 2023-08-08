using Script.Player_Controller;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class HealPetalItemController : MonoBehaviour
    {
        private const string PLAYER_TAG = "PlayerCharacter";

        [SerializeField] private PlayerHealthController m_playerHealthController;

        private const float m_healAmount = 10f;

        private void OnTriggerEnter2D(Collider2D p_collided)
        {
            if (p_collided.CompareTag(PLAYER_TAG))
            {
                m_playerHealthController.HealPlayerHealth(m_healAmount);
                gameObject.SetActive(false);
            }
        }
    }
}
