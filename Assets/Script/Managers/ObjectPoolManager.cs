using System;
using Script.Object_Pool;
using UnityEngine;

namespace Script.Managers
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance;
        
        [SerializeField] private PlantItemObjectPool m_plantItemObjectPool;
        public PlantItemObjectPool PlantItemObjectPool => m_plantItemObjectPool;

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
    }
}
