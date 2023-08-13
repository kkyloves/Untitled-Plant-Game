using DG.Tweening;
using Script.Monster_Controller;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantPoisonController : MonoBehaviour
    {
        private float m_damage;
        private float m_maxRange = 5f;
        
        private void Awake()
        {
            PlayPoisonAnimation();
        }

        public void SetDamage(float p_damage)
        {
            m_damage = p_damage;
        }

        public void SetRange(float p_range)
        {
            m_maxRange = p_range;
        }

        private void PlayPoisonAnimation()
        {
            transform.DOScale(m_maxRange -1f, 0f);

            transform.DOScale(m_maxRange, 1f).OnComplete(() =>
            {
                transform.DOScale(m_maxRange - 1f, 1f);
            }).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnTriggerEnter2D(Collider2D p_collided)
        {
            if (p_collided.CompareTag("Monster"))
            {
                var monsterHealthController = p_collided.GetComponent<MonsterHealthController>();
                if (monsterHealthController != null)
                {
                    monsterHealthController.DamageMonster(m_damage, true);
                }
                else
                {
                    Debug.Log("Monster Health Controller not found!");
                }
            }
        }

        private void OnTriggerExit2D(Collider2D p_collided)
        {
            if (p_collided.CompareTag("Monster"))
            {
                var monsterHealthController = p_collided.GetComponent<MonsterHealthController>();
                if (monsterHealthController != null)
                {
                    monsterHealthController.ResetPoisonEffect();
                }
            }
        }
    }
}
