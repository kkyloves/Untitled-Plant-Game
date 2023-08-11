using Script.Loot_Controller;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Scriptable_Object
{
    [CreateAssetMenu(menuName = "Create Loot Item Details/Loot Item Detail")]
    public class LootItemDetails : ScriptableObject
    {
        [SerializeField] private string m_lootId;
        [SerializeField] private LootType m_lootType;
        [SerializeField] private Sprite m_lootSprite;
        [ShowIf("m_lootType", LootType.Seed)] [SerializeField] private PlantItemDetails m_plantItemDetails;
        [SerializeField] private float m_chanceToSpawn = 50f;

        public LootType LootType => m_lootType;
        public Sprite LootSprite => m_lootSprite;
        public float ChanceToSpawn => m_chanceToSpawn;
        public PlantItemDetails PlantItemDetails => m_plantItemDetails;
    }
}
