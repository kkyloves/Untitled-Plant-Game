using Script.Scriptable_Object;
using UnityEngine;

namespace Script.Player_Controller
{
    public class PlayerGeneralController : MonoBehaviour
    {
        public static PlayerGeneralController Instance;

        [SerializeField] private PlayerHealthController m_playerHealthController;
        public PlayerHealthController PlayerHealthController => m_playerHealthController;

        [SerializeField] private PlayerPlantingController m_playerPlantingController;
        public PlayerPlantingController PlayerPlantingController => m_playerPlantingController;
        
        
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
    }
}
