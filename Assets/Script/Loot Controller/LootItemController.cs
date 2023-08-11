using System;
using System.Collections;
using DG.Tweening;
using Script.Player_Controller;
using Script.Scriptable_Object;
using UnityEngine;

namespace Script.Loot_Controller
{
    public enum LootType
    {
        Seed,
        Health
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

        private void Awake()
        {
            m_baseSpriteRenderer = GetComponent<SpriteRenderer>();
            m_circleCollider2D = GetComponent<CircleCollider2D>();
        }

        public void Init(LootItemDetails p_lootItemDetails, Vector2 p_spawnPosition)
        {
            m_isSpawned = true;
            m_lootItemDetails = p_lootItemDetails;
            
            m_baseSpriteRenderer.sprite = m_lootItemDetails.LootSprite;

            switch (m_lootItemDetails.LootType)
            {
                case LootType.Seed:
                    m_seedIcon.sprite = m_lootItemDetails.SeedSprite;
                    m_seedIcon.gameObject.SetActive(true);
                    break;
                case LootType.Health:
                    m_seedIcon.gameObject.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            transform.position = new Vector2(p_spawnPosition.x, p_spawnPosition.y);
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
                    .OnComplete( () =>
                    {
                        player.AddSeedCount(m_lootItemDetails.PlantItemDetails, 1);
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
