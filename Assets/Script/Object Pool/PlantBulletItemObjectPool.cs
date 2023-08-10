using System.Collections.Generic;
using Script.Plant_Controller;
using UnityEngine;

namespace Script.Object_Pool
{
    public class PlantBulletItemObjectPool : ObjectPool
    {
        private void Start()
        {
            CreatePool();
        }
        
        public PlantBulletController GetPlantBulletItem()
        {
            var item = GetItem();
            var bullet = item.GetComponent<PlantBulletController>();

            if (bullet != null)
            {
                if(!bullet.IsDeployed)
                {
                    return bullet;
                }
            }
            else
            {
                Debug.Log("No Plant Bullet Item Controller Found!");
            }

            return null;
        }
    }
}
