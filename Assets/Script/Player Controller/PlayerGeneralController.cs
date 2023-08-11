using Script.Scriptable_Object;
using UnityEngine;

namespace Script.Player_Controller
{
    public class PlayerGeneralController : MonoBehaviour
    {
        public static PlayerGeneralController Instance;

        [SerializeField] private PlayerHealthController m_playerHealthController;
        [SerializeField] private PlayerPlantingController m_playerPlantingController;
        
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

        public void AddSeedCount(PlantItemDetails p_lootedPlantItemDetails, int p_seedCount)
        {
            m_playerPlantingController.AddSeedCount(p_lootedPlantItemDetails, p_seedCount);
        }

        public void HealPlayerHealth(float p_healAmount)
        {
            m_playerHealthController.HealPlayerHealth(p_healAmount);
        }

        public void InflictPlayerHealth(float p_damage)
        {
            m_playerHealthController.InflictPlayerHealth(p_damage);
        }
    }
}
