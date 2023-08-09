using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantShooterController : MonoBehaviour
    {
        private const float CAN_SHOOT_TIMER = 1f;
        [SerializeField] private GameObject m_bullet;

        private Transform m_monsterPosition;
        private bool m_canShoot = true;

        private void FireBullet()
        {
            var bullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
            bullet.transform.DOMove(m_monsterPosition.position, 1.5f);

            //var bulletRigidBody2D = bullet.GetComponent<Rigidbody2D>();
            //bulletRigidBody2D.velocity = 5f * m_monsterPosition.transform.position;
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Monster") && m_canShoot)
            {
                m_canShoot = false;
                m_monsterPosition = col.GetComponent<Transform>();
                FireBullet();

                StartCoroutine(StartShootTimer());
            }
        }

        private IEnumerator StartShootTimer()
        {
            yield return new WaitForSeconds(CAN_SHOOT_TIMER);
            m_canShoot = true;
        }
    }
}
