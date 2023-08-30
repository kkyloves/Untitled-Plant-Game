using System.Collections;
using Script.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Monster_Controller
{
    public class MonsterSpawnManager : MonoBehaviour
    {
        private const int BASE_ADDITIONAL_MONSTER = 1;
        private const float TIMER_SPAWNER = 1f;
        private const float MONSTER_THRESHOLD = 500f;

        [SerializeField] private Transform[] m_monsterSpawnPoints;
        
        private int m_spawnSpeed = 1;

        private int m_totalActiveMonster;
        private int m_totalSpawnMonster;

        public void StartMonsterSpawn()
        {
            InvokeRepeating(nameof(SpawnMonster), 0f, 1f);
        }

        private void SpawnMonster()
        {
            StartCoroutine(SpawnMonsterCoroutine());
        }

        private IEnumerator SpawnMonsterCoroutine()
        {
            while (m_totalActiveMonster >= MONSTER_THRESHOLD)
            {
                yield return null;
            }
            
            yield return new WaitForSeconds(TIMER_SPAWNER);
            
            for (var i = 0; i < m_spawnSpeed; i++)
            {
                var random = Random.Range(0, m_monsterSpawnPoints.Length);
                var spawnPoint = m_monsterSpawnPoints[random];

                var monster = GameManager.Instance.ObjectPoolManager.MonsterObjectPool.GetMonster();
                monster.transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);

                var player = GameManager.Instance.PlayerGeneralController;
                var monsterMovementController = monster.GetComponent<MonsterMovementController>();
                monsterMovementController.SetTarget(player.transform);
                monster.GetComponent<MonsterHealthController>().Reset();

                GameManager.Instance.RewardEffectManager.UpdateMonster(monsterMovementController);

                m_totalSpawnMonster++;
                m_totalActiveMonster++;
                
                if (m_totalSpawnMonster % 100 == 0)
                {
                    m_spawnSpeed += BASE_ADDITIONAL_MONSTER;
                }
                
                monster.SetActive(true);
            }
        }

        public void DeductActiveCount()
        {
            m_totalActiveMonster--;
        }
    }
}
