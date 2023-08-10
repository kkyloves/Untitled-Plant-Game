using System.Collections.Generic;
using UnityEngine;

namespace Script.Object_Pool
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject m_plantBulletPrefab;
        [SerializeField] private int m_initialAmountToPool;
        [SerializeField] private bool m_canExpand = true;

        private List<GameObject> m_objectPoolList;
        
        protected void CreatePool()
        {
            m_objectPoolList = new List<GameObject>();

            for(var i = 0; i < m_initialAmountToPool; i++)
            {
                var instantiatedObject = Instantiate(m_plantBulletPrefab, transform, true);
                
                if (instantiatedObject != null)
                {
                    instantiatedObject.SetActive(false);
                    m_objectPoolList.Add(instantiatedObject);
                }
                else
                {
                    Debug.Log("No Game Object Prefab Found!");
                }
            }      
        }

        protected GameObject GetItem()
        {
            foreach (var item in m_objectPoolList)
            {
                if(!item.activeInHierarchy && !item.activeSelf)
                {
                    return item;
                }
            }
            
            if (m_canExpand) 
            {
                var instantiatedObject = Instantiate(m_plantBulletPrefab, transform, true);
                instantiatedObject.SetActive(false);
                m_objectPoolList.Add(instantiatedObject);
                return instantiatedObject;
            }

            return null;
        }
    }
}
