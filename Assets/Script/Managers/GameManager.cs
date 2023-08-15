using Script.Loot_Controller;
using Script.Monster_Controller;
using Script.Player_Controller;
using Script.Rewards_Controller;
using UnityEngine;

namespace Script.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private PlayerGeneralController m_playerGeneralController;
        public PlayerGeneralController PlayerGeneralController => m_playerGeneralController;

        [SerializeField] private ObjectPoolManager m_objectPoolManager;
        public ObjectPoolManager ObjectPoolManager => m_objectPoolManager;

        [SerializeField] private UIManager m_uiManager;
        public UIManager UIManager => m_uiManager;

        [SerializeField] private RewardEffectManager m_rewardEffectManager;
        public RewardEffectManager RewardEffectManager => m_rewardEffectManager;

        [SerializeField] private LootItemManager m_lootItemManager;
        public LootItemManager LootItemManager => m_lootItemManager;

        [SerializeField] private MonsterSpawnManager m_monsterSpawnManager;
        public MonsterSpawnManager MonsterSpawnManager => m_monsterSpawnManager;

        
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }

        private void Start()
        {
            Time.timeScale = 1f;
            m_monsterSpawnManager.StartMonsterSpawn();
        }
    }
}
