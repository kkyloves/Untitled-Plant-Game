using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Scriptable_Object
{
    public enum RewardGeneralType
    {
        Squash,
        Mushroom,
        Health,
        Player,
        Loot
    }

    public enum RewardEffect
    {
        AddLootChance,
        MoveSpeed,
        Projectile,
        AllAddDamage,
        AddDamageSquash,
        AddDamageMushroom,
        AddPoisonRange,
        FasterFireRate,
        GiveMoreHealth,
        PlantFaster,
        SlowerPoison,
    }
    
    [CreateAssetMenu(menuName = "Create Reward Item Details/Reward Item Detail")]
    public class RewardItemDetails : ScriptableObject
    {
        [SerializeField] private string m_rewardId;
        [SerializeField] private string m_rewardMessage;
        [SerializeField] private RewardGeneralType m_rewardGeneralType;
        [SerializeField] private RewardEffect m_rewardEffect;
        
       // [ShowIf("m_rewardGeneralType", RewardGeneralType.Loot)] 
        [SerializeField] private LootItemDetails m_lootItemDetails;

        public string RewardMessage => m_rewardMessage;
        public RewardGeneralType RewardGeneralType => m_rewardGeneralType;
        public RewardEffect RewardEffect => m_rewardEffect;

        public LootItemDetails LootItemDetails => m_lootItemDetails;


    }
}
