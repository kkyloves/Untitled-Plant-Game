using Script.Managers;
using Script.Scriptable_Object;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Script.Player_Controller
{
    public class PlayerPlantingController : MonoBehaviour
    {
        [SerializeField] private PlantItemDetails[] m_plantItemDetails;
        [SerializeField] private SpriteRenderer m_sproutSpriteRenderer;
        private PlayerAnimationController m_playerAnimationController;

        public Transform m_plantPosition;
        private PlantItemDetails m_randomPlantItemDetails;

        private void Awake()
        {
            m_playerAnimationController = GetComponent<PlayerAnimationController>();
        }

        public void PlantingAnimationDone()
        {
            var plantTo = ObjectPoolManager.Instance.PlantItemObjectPool.GetPlantItem();
            if (plantTo)
            {
                plantTo.Init(m_randomPlantItemDetails.FullGrownSprite, m_plantPosition.position);
            }
            else
            {
                Debug.Log("No Plant Item Get!");
            }
        }

        private void OnPlantHold()
        {
            m_randomPlantItemDetails = GetRandomPlantItemDetails();
            m_sproutSpriteRenderer.sprite = m_randomPlantItemDetails.PlantSproutSprite;
            m_playerAnimationController.PlayPlantingAnimation();
        }

        private PlantItemDetails GetRandomPlantItemDetails()
        {
            var index = Random.Range(0, m_plantItemDetails.Length);
            return m_plantItemDetails[index];
        }
}
}
