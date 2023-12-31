using UnityEngine;

namespace Script.Scriptable_Object
{
    [CreateAssetMenu(menuName = "Create Plant Item Details/Plant Item Detail")]
    public class PlantItemDetails : ScriptableObject
    {
        [SerializeField] private string m_plantId;
        [SerializeField] private Sprite m_plantSproutSprite;
        [SerializeField] private Sprite m_fullGrownSprite;
        [SerializeField] private PlantSkill m_plantSkill;

        public string PlantId => m_plantId;
        public Sprite PlantSproutSprite => m_plantSproutSprite;
        public Sprite FullGrownSprite => m_fullGrownSprite;
        public PlantSkill PlantSkill => m_plantSkill;
    }

    public enum PlantSkill
    {
        Shooting,
        Poison
    }
}
