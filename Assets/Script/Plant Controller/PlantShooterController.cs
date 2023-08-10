using System.Collections;
using DG.Tweening;
using Script.Managers;
using Script.Monster_Controller;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantShooterController : MonoBehaviour
    {
        private const float CAN_SHOOT_TIMER = 0.5f;
        
        [SerializeField] private Transform m_plantTransform;
        
        private Transform m_monsterPosition;
        private bool m_canShoot = true;

        public void Init()
        {
            m_monsterPosition = null;
            m_canShoot = true;
        }

        private void FireBullet()
        {
            if (m_monsterPosition != null)
            {
                PlayShootingAnimation();
                
                var bullet = ObjectPoolManager.Instance.PlantBulletItemObjectPool.GetPlantBulletItem();
                bullet.transform.position = new Vector2(transform.position.x, transform.position.y);

                // bullet.transform.DOMove(m_monsterPosition.position, 1.5f);

                bullet.Init(m_monsterPosition,transform.position);
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
            yield return new WaitForSeconds(CAN_SHOOT_TIMER);
            m_canShoot = true;
        }
    }
}
