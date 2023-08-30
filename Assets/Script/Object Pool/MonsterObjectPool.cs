using UnityEngine;

namespace Script.Object_Pool
{
    public class MonsterObjectPool : ObjectPool
    {
        private void Start()
        {
            CreatePool();
        }

        public GameObject GetMonster()
        {
            return GetItem();
        }
    }
}
