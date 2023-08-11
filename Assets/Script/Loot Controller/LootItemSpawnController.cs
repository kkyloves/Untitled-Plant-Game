using Script.Managers;
using Script.Scriptable_Object;
using UnityEngine;

namespace Script.Loot_Controller
{
    public class LootItemSpawnController : MonoBehaviour
    {
        public static LootItemSpawnController Instance;
        [SerializeField] private LootItemDetails[] m_lootItemDetails;
        
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

        public void SpawnLootItems(Vector2 p_spawnPosition)
        {
            foreach (var lootItem in m_lootItemDetails)
            {
                var random = Random.Range(0f, 100f);
                if (lootItem.ChanceToSpawn >= random)
                {
                    var loot = ObjectPoolManager.Instance.LootItemObjectPool.GetLootItem();
                    loot.Init(lootItem, p_spawnPosition);
                }
            }
        }
        
        
        
        

    }
}
