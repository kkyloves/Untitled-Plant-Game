using UnityEngine;

namespace Script.Player_Controller
{
    public class PlayerGeneralController : MonoBehaviour
    {
        public static PlayerGeneralController Instance;

        [SerializeField] private PlayerHealthController m_playerHealthController;
        public PlayerHealthController PlayerHealthController => m_playerHealthController;
        
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
