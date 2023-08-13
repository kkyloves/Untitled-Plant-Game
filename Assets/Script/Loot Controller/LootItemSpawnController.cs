using System.Collections.Generic;
using System.Data.Common;
using Script.Managers;
using Script.Rewards_Controller;
using Script.Scriptable_Object;
using Unity.VisualScripting;
using UnityEngine;

namespace Script.Loot_Controller
{
    public class LootItemSpawnController : MonoBehaviour
    {
        public static LootItemSpawnController Instance;
        [SerializeField] private LootItemDetails[] m_lootItemDetails;

        private List<string> m_lootList;

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

            m_lootList = new List<string>();
            foreach (var loot in m_lootItemDetails)
            {
                m_lootList.Add(loot.LootId);
            }
        }

        public void SpawnLootItems(Vector2 p_spawnPosition)
        {
            var random = Random.Range(0, m_lootList.Count);
            var loot = ObjectPoolManager.Instance.LootItemObjectPool.GetLootItem();
            var lootItem = GetLootItemDetailsById(m_lootList[random]);
            
            loot.Init(lootItem, p_spawnPosition);
            RewardEffectController.Instance.UpdateLoot(loot); 
        }
        
        private LootItemDetails GetLootItemDetailsById(string p_lootItemId)
        {
            foreach (var loot in m_lootItemDetails)
            {
                if (loot.LootId.Equals(p_lootItemId))
                {
                    return loot;
                }
            }
            
            Debug.Log("No Loot Item with this Id found!");
            return null;
        }

        public void AddLootChance(string p_lootId)
        {
            m_lootList.Add(p_lootId);
        }
    }
}
