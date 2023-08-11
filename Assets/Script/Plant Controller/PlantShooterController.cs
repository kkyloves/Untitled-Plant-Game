using System.Collections;
using DG.Tweening;
using Script.Managers;
using Script.Monster_Controller;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantShooterController : MonoBehaviour
    {
        [SerializeField] private Transform m_plantTransform;
        
        private Transform m_monsterPosition;
        private bool m_canShoot = true;

        private float m_canShootTimer = 0.5f;
        private bool m_isProjectile = true;

        public void Init()
        {
            m_monsterPosition = null;
            m_canShoot = true;
        }

        public void TurnOnProjectileEffect()
        {
            m_isProjectile = true;
        }

        public void MakeShootTimerFaster()
        {
            m_canShootTimer -= 0.1f;
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
                        var bullet = ObjectPoolManager.Instance.PlantBulletItemObjectPool.GetPlantBulletItem();
                        bullet.transform.position = new Vector2(transform.position.x, transform.position.y);
                        
                        bullet.Init(updatedMonsterPosition,transform.position);
                    }
                }
                else
                {
                    var bullet = ObjectPoolManager.Instance.PlantBulletItemObjectPool.GetPlantBulletItem();
                    bullet.transform.position = new Vector2(transform.position.x, transform.position.y);
                    
                    bullet.Init(m_monsterPosition.position,transform.position);
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
