using Script.Plant_Controller;
using UnityEngine;

namespace Script.Object_Pool
{
    public class PlantItemObjectPool : ObjectPool
    {
        private void Start()
        {
            CreatePool();
        }

        public PlantItemController GetPlantItem()
        {
            var item = GetItem();
            var plantItem = item.GetComponent<PlantItemController>();

            if (plantItem != null)
            {
                if(!plantItem.IsPlanted)
                {
                    return plantItem;
                }
            }
            else
            {
                Debug.Log("No Plant Item Controller Found!");
            }
            
            return null;
        }
    }
}
