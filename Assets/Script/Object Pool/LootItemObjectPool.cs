using System;
using Script.Loot_Controller;
using UnityEngine;

namespace Script.Object_Pool
{
    public class LootItemObjectPool : ObjectPool
    {
        private void Start()
        {
            CreatePool();
        }
        
        public LootItemController GetLootItem()
        {
            var item = GetItem();
            var lootItem = item.GetComponent<LootItemController>();

            if (lootItem != null)
            {
                if(!lootItem.IsSpawned)
                {
                    return lootItem;
                }
            }
            else
            {
                Debug.Log("No Loot Item Controller Found!");
            }

            return null;
        }
    }
}
