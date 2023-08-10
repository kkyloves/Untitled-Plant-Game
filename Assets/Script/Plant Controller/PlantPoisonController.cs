using System;
using DG.Tweening;
using Script.Monster_Controller;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantPoisonController : MonoBehaviour
    {
        private void Awake()
        {
            PlayPoisonAnimation();
        }

        private void PlayPoisonAnimation()
        {
            transform.DOScale(4f, 0f);

            transform.DOScale(5f, 1f).OnComplete(() =>
            {
                transform.DOScale(4f, 1f);
            }).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnTriggerEnter2D(Collider2D p_collided)
        {
            if (p_collided.CompareTag("Monster"))
            {
                var monsterHealthController = p_collided.GetComponent<MonsterHealthController>();
                if (monsterHealthController != null)
                {
                    monsterHealthController.DamageMonster(5f, true);
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
