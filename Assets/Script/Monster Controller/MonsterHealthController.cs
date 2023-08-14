using System.Collections;
using DG.Tweening;
using Script.Managers;
using UnityEngine;

namespace Script.Monster_Controller
{
    public class MonsterHealthController : MonoBehaviour
    {
        private const float CONTINUOUS_TIMER = 0.5f;
        private float m_totalHealth = 100;

        private bool m_isPoisoned;
        private float m_poisonDamage;

        private Tween m_hitEffectTween;

        private MonsterMovementController m_movementController;
        private SpriteRenderer m_spriteRenderer;

        private bool m_isDead;
        public bool IsDead => m_isDead;
        
        private void Awake()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_movementController = GetComponent<MonsterMovementController>();

            SetInvulnerableAnimation();
        }
        
        public void Reset()
        {
            if (m_isPoisoned)
            {
                ResetPoisonEffect();
            }

            // m_spriteRenderer.DOFade(1f, 0f);
            m_hitEffectTween.Pause();
            m_totalHealth = 100;
            m_isDead = false;
        }

        private void SetInvulnerableAnimation()
        {
            m_spriteRenderer.DOFade(1f, 0f);

            m_hitEffectTween = m_spriteRenderer.DOFade(0.2f, 0.1f).OnComplete(() =>
            {
                m_spriteRenderer.DOFade(1f, 0.1f);
            }).SetLoops(-1, LoopType.Yoyo);

            m_spriteRenderer.DOFade(1f, 0f);
            m_hitEffectTween.Pause();
        }

        public void DamageMonster(float p_damage, bool p_isPoison)
        {
            if (!m_isDead)
            {
                if (p_isPoison)
                {
                    m_poisonDamage = p_damage;
                    m_isPoisoned = true;

                    StartCoroutine(ContinuousDamage());
                    m_movementController.ApplyPoisonEffect();
                }
                else
                {
                    m_totalHealth -= p_damage;

                    StopCoroutine(StopHitEffect());
                    m_hitEffectTween.Pause();
                    m_spriteRenderer.DOFade(1f, 0f);

                    m_hitEffectTween.Play();
                    StartCoroutine(StopHitEffect());
                }
                
                if (m_totalHealth <= 0f)
                {
                    m_isDead = true;
                    StopAllCoroutines();
                    
                    GameManager.Instance.LootItemManager.SpawnLootItems(transform.position);
                    GameManager.Instance.UIManager.AddExp();
                    GameManager.Instance.UIManager.AddChickenKilledCount();
                    
                    m_hitEffectTween.Restart();
                    m_spriteRenderer.DOFade(1f, 0f);
                    m_hitEffectTween.Pause();
                    
                    gameObject.SetActive(false);
                }
            }
        }

        private IEnumerator StopHitEffect()
        {
            yield return new WaitForSeconds(1f);
            m_hitEffectTween.Restart();
            m_spriteRenderer.DOFade(1f, 0f);
            m_hitEffectTween.Pause();
        }

        private IEnumerator ContinuousDamage()
        {
            while (m_isPoisoned)
            {
                m_totalHealth -= m_poisonDamage;
                
                StopCoroutine(StopHitEffect());
                m_hitEffectTween.Pause();
                m_spriteRenderer.DOFade(1f, 0f);
                
                m_hitEffectTween.Play();
                StartCoroutine(StopHitEffect());
                
                yield return new WaitForSeconds(CONTINUOUS_TIMER);
            }
        }

        public void ResetPoisonEffect()
        {
            m_isPoisoned = false;
            m_movementController.ResetPoisonEffect();
        }
        
        public bool CanBeTarget()
        {
            return !m_isDead;
        }
    }
}