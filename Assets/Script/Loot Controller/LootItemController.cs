using System;
using System.Collections;
using DG.Tweening;
using Script.Managers;
using Script.Player_Controller;
using Script.Scriptable_Object;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Loot_Controller
{
    public enum LootType
    {
        Seed,
        Heal
    }

    public class LootItemController : MonoBehaviour
    {
        private const float TIMER_TO_ACTIVATE_COLLIDER = 1f;

        [SerializeField] private SpriteRenderer m_seedIcon;

        private bool m_isSpawned;
        public bool IsSpawned => m_isSpawned;

        private CircleCollider2D m_circleCollider2D;
        private SpriteRenderer m_baseSpriteRenderer;
        private LootItemDetails m_lootItemDetails;

        private UIManager m_uiManager;

        private float m_healAdd = 30f;

        private void Awake()
        {
            m_baseSpriteRenderer = GetComponent<SpriteRenderer>();
            m_circleCollider2D = GetComponent<CircleCollider2D>();
        }

        public void SetHealEffect(float p_healEffect)
        {
            m_healAdd = p_healEffect;
        }

        public void Init(LootItemDetails p_lootItemDetails, Vector2 p_spawnPosition)
        {
            m_isSpawned = true;
            m_lootItemDetails = p_lootItemDetails;

            m_baseSpriteRenderer.sprite = m_lootItemDetails.LootSprite;

            switch (m_lootItemDetails.LootType)
            {
                case LootType.Seed:
                    m_seedIcon.sprite = m_lootItemDetails.PlantItemDetails.PlantSproutSprite;
                    m_seedIcon.gameObject.SetActive(true);
                    break;
                case LootType.Heal:
                    m_seedIcon.gameObject.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            transform.position = new Vector2(p_spawnPosition.x, p_spawnPosition.y);
            var jumpPosition = new Vector2(p_spawnPosition.x + Random.Range(-1f, 1f),
                p_spawnPosition.y + Random.Range(-1f , 1f));
            transform.DOMove(jumpPosition, 0.1f);
            gameObject.SetActive(true);

            StartCoroutine(ActivateLootCollider());
        }

        private IEnumerator ActivateLootCollider()
        {
            yield return new WaitForSeconds(TIMER_TO_ACTIVATE_COLLIDER);
            m_circleCollider2D.enabled = true;
        }

        public void OnTriggerEnter2D(Collider2D p_collider)
        {
            if (p_collider.CompareTag("PlayerCharacter"))
            {
                var player = p_collider.GetComponent<PlayerGeneralController>();
                
                DoTweenFollow.DOMoveInTargetLocalSpace(transform, player.transform, Vector2.zero, 0.2f)
                    .OnComplete(() =>
                    {
                        switch (m_lootItemDetails.LootType)
                        {
                            case LootType.Seed:
                                {
                                    player.AddSeedCount(m_lootItemDetails.PlantItemDetails, 1);
                                }
                                break;
                            case LootType.Heal:
                                {
                                    m_uiManager.HealPlayerHealth(m_healAdd);
                                }
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        Disappear();
                    });
            }
        }

        private void Disappear()
        {
            m_isSpawned = false;
            m_circleCollider2D.enabled = false;
            gameObject.SetActive(false);
        }
    }
}