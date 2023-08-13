using Script.Object_Pool;
using UnityEngine;

namespace Script.Managers
{
    public class ObjectPoolManager : MonoBehaviour
    {
        [SerializeField] private PlantItemObjectPool m_plantItemObjectPool;
        public PlantItemObjectPool PlantItemObjectPool => m_plantItemObjectPool;
        
        [SerializeField] private PlantBulletItemObjectPool m_plantBulletItemObjectPool;
        public PlantBulletItemObjectPool PlantBulletItemObjectPool => m_plantBulletItemObjectPool;
        
        [SerializeField] private MonsterObjectPool m_monsterObjectPool;
        public MonsterObjectPool MonsterObjectPool => m_monsterObjectPool;
        
        [SerializeField] private LootItemObjectPool m_lootItemObjectPool;
        public LootItemObjectPool LootItemObjectPool => m_lootItemObjectPool;
    }
}
