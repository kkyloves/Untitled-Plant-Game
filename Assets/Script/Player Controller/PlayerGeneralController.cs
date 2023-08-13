using Script.Scriptable_Object;
using UnityEngine;

namespace Script.Player_Controller
{
    public class PlayerGeneralController : MonoBehaviour
    {
        [SerializeField] private PlayerPlantingController m_playerPlantingController;
        [SerializeField] private PlayerAnimationController m_playerAnimationController;
        [SerializeField] private PlayerMovementController m_playerMovementController;
        
        public void AddSeedCount(PlantItemDetails p_lootedPlantItemDetails, int p_seedCount)
        {
            m_playerPlantingController.AddSeedCount(p_lootedPlantItemDetails, p_seedCount);
        }
        
        public void SetMovementSpeed(float p_speed)
        {
            m_playerMovementController.SetMovementSpeed(p_speed);
        }

        public void SetPlayerPlantAnimationSpeed(float p_speed)
        {
            m_playerAnimationController.SetPlayerPlantAnimationSpeed(p_speed);
        }
    }
}
