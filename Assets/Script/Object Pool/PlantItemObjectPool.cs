using System.Collections.Generic;
using Script.Plant_Controller;
using UnityEngine;

namespace Script.Object_Pool
{
    public class PlantItemObjectPool : MonoBehaviour
    {
        [SerializeField] private PlantItemController m_plantItemControllerPrefab;
        [SerializeField] private int m_initialAmountToPool;

        private List<PlantItemController> m_plantItemControllersPool;
        private int m_currentObjectPoolCounter;

        private void Start()
        {
            m_plantItemControllersPool = new List<PlantItemController>();

            for(var i = 0; i < m_initialAmountToPool; i++)
            {
                var instantiatedObject = Instantiate(m_plantItemControllerPrefab, transform, true);
                var plant = instantiatedObject.GetComponent<PlantItemController>();
                
                if (plant)
                {
                    instantiatedObject.Disappear();
                    m_plantItemControllersPool.Add(plant);
                }
                else
                {
                    Debug.Log("No Plant Item Controller Found!");
                }
            }        
        }

        public PlantItemController GetPlantItem()
        {
            foreach (var plantItem in m_plantItemControllersPool)
            {
                if(!plantItem.IsPlanted)
                {
                    return plantItem;
                }
            }

            return null;
        }

        private void ExtendObjectPool()
        {
            
        }
    }
}
