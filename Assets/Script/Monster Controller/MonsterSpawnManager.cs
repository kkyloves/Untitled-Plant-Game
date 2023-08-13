using Script.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Monster_Controller
{
    public class MonsterSpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform[] m_monsterSpawnPoints;
        private float m_spawnSpeed = 1f;
        
        private void Awake()
        {
            InvokeRepeating(nameof(SpawnMonster), 0f, 1f);
        }
        
        private void SpawnMonster()
        {
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

                monster.SetActive(true);
            }
        }
    }
}
