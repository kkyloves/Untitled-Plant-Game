using System;
using System.Collections;
using DG.Tweening;
using Script.Managers;
using Script.Monster_Controller;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Plant_Controller
{
    public class PlantShooterController : MonoBehaviour
    {
        [SerializeField] private Transform m_plantTransform;
        
        private Transform m_monsterPosition;
        private bool m_canShoot = true;

        private float m_canShootTimer = 0.8f;
        private bool m_isProjectile = true;
        private float m_damage = 20f;
        
        public void Init()
        {
            m_monsterPosition = null;
            m_canShoot = true;
        }

        public void SetProjectileEffect(bool p_isProjectile)
        {
            m_isProjectile = p_isProjectile;
        }

        public void SetDamage(float p_damage)
        {
            m_damage = p_damage;
        }

        public void SetShootTimerFaster(float p_fireRate)
        {
            m_canShootTimer = p_fireRate;
        }

        private void FireBullet()
        {
            if (m_monsterPosition != null)
            {
                PlayShootingAnimation();
                
                if (m_isProjectile)
                {
                    for (var i = 0; i < Random.Range(3, 7); i++)
                    {
                        var updatedMonsterPosition = new Vector2(m_monsterPosition.position.x + i, m_monsterPosition.position.y  + i);
                        var bullet = GameManager.Instance.ObjectPoolManager.PlantBulletItemObjectPool.GetPlantBulletItem();
                        bullet.transform.position = new Vector2(transform.position.x, transform.position.y);
                        
                        bullet.Init(updatedMonsterPosition,transform.position, m_damage);
                    }
                }
                else
                {
                    var bullet = GameManager.Instance.ObjectPoolManager.PlantBulletItemObjectPool.GetPlantBulletItem();
                    bullet.transform.position = new Vector2(transform.position.x, transform.position.y);
                    
                    bullet.Init(m_monsterPosition.position,transform.position, m_damage);
                }
            }
            else
            {   
                Debug.Log("No Monster Position Detected!");
            }
        }

        private void PlayShootingAnimation()
        {
            m_plantTransform.DOScale(1.2f, 0.2f).OnComplete(() =>
            {
                m_plantTransform.DOScale(1f, 0.2f);
            });
        }

        private void OnTriggerStay2D(Collider2D p_collided)
        {
            if (p_collided.CompareTag("Monster") && m_canShoot)
            {
                var canBeTarget = p_collided.GetComponent<MonsterHealthController>().CanBeTarget();

                if (canBeTarget)
                {
                    m_canShoot = false;
                    m_monsterPosition = p_collided.GetComponent<Transform>();
                    
                    FireBullet();
                    StartCoroutine(StartShootTimer());
                }
            }
        }

        private IEnumerator StartShootTimer()
        {
            yield return new WaitForSeconds(m_canShootTimer);
            m_canShoot = true;
        }
    }
}
