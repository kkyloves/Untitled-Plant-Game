using Script.Managers;
using Script.Player_Controller;
using Script.Rewards_Controller;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Monster_Controller
{
    public class MonsterSpawnController : MonoBehaviour
    {
        [SerializeField] private Transform[] m_monsterSpawnPoints;

        private void Awake()
        {
            InvokeRepeating(nameof(SpawnMonster), 0f, 1f);
        }

        private void SpawnMonster()
        {
            var random = Random.Range(0, m_monsterSpawnPoints.Length);
            var spawnPoint = m_monsterSpawnPoints[random];
            
            var monster = ObjectPoolManager.Instance.MonsterObjectPool.GetMonster();
            monster.transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);

            var player = PlayerGeneralController.Instance;
            var monsterMovementController = monster.GetComponent<MonsterMovementController>();
            monsterMovementController.SetTarget(player.transform);
            monster.GetComponent<MonsterHealthController>().Reset();
            
            RewardEffectController.Instance.UpdateMonster(monsterMovementController);

            monster.SetActive(true);
        }
    }
}
