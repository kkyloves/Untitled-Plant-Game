using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Managers;
using Script.Scriptable_Object;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Script.Player_Controller
{
    [Serializable]
    public class PlantContainer
    {
        public PlantItemDetails PlantItemDetails;
        public int PlantSeedCount;
    }

    public class PlayerPlantingController : MonoBehaviour
    {
        private const int INITIAL_SEED_COUNT = 5;

        [SerializeField] private SpriteRenderer m_sproutSpriteRenderer;
        
        [SerializeField] private Sprite m_warningNoSeedSign;
        [SerializeField] private Image m_seedIconToChoose;
        [SerializeField] private GameObject m_seedIconUI;
        [SerializeField] private Transform m_seedTopAnimationTopPoint;
        [SerializeField] private Transform m_seedTopAnimationBottomPoint;
        
        [SerializeField] private GameObject m_angelPlants;
        [SerializeField] private Transform m_plantPosition;
        
        [SerializeField] private PlantItemDetails[] m_plantItemDetails;


        private PlayerAnimationController m_playerAnimationController;
        public List<PlantContainer> m_plantContainer;


        public PlantContainer m_currentChosenPlantContainer;
        private int m_currentChosenIndexPlantContainer;

        private void Awake()
        {
            m_playerAnimationController = GetComponent<PlayerAnimationController>();
            InitializePlantSeeds();
        }

        private void InitializePlantSeeds()
        {
            m_plantContainer = new List<PlantContainer>();

            foreach (var plantItemDetails in m_plantItemDetails)
            {
                PlantContainer plantContainer = new()
                {
                    PlantItemDetails = plantItemDetails,
                    PlantSeedCount = INITIAL_SEED_COUNT
                };

                m_plantContainer.Add(plantContainer);
            }
            
            m_currentChosenIndexPlantContainer = 0;
            m_currentChosenPlantContainer = m_plantContainer[m_currentChosenIndexPlantContainer];
            SetPlantChoiceUI();
        }

        public void AddSeedCount(PlantItemDetails p_lootedPlantItemDetails, int p_seedCount)
        {
            var plantContainer = GetPlantContainer(p_lootedPlantItemDetails);

            if (plantContainer != null)
            {
                plantContainer.PlantSeedCount += p_seedCount;
                GameManager.Instance.UIManager.UpdateSeedCount(plantContainer.PlantItemDetails.PlantSkill, plantContainer.PlantSeedCount);
            }
            else
            {
                PlantContainer container = new()
                {
                    PlantItemDetails = p_lootedPlantItemDetails,
                    PlantSeedCount = p_seedCount
                };

                var needToInitialize = m_plantContainer.Count <= 0;

                m_plantContainer.Add(container);
                GameManager.Instance.UIManager.UpdateSeedCount(container.PlantItemDetails.PlantSkill, container.PlantSeedCount);
                
                if (needToInitialize)
                {
                    m_currentChosenIndexPlantContainer = 0;
                    m_currentChosenPlantContainer = m_plantContainer[m_currentChosenIndexPlantContainer];
                    SetPlantChoiceUI();
                    
                    m_angelPlants.SetActive(false);
                }
            }
        }

        private PlantContainer GetPlantContainer(Object p_plantItemDetails)
        {
            foreach (var plantContainer in m_plantContainer)
            {
                if (plantContainer.PlantItemDetails == p_plantItemDetails)
                {
                    return plantContainer;
                }
            }

            Debug.Log("Plant ID Not Found in Plant Item Container, Add it!");
            return null;
        }

        public void PlantingAnimationDone()
        {
            var plant = GameManager.Instance.ObjectPoolManager.PlantItemObjectPool.GetPlantItem();

            if (plant != null) 
            {
                var plantItemDetails = m_currentChosenPlantContainer.PlantItemDetails;
                Debug.Log(plantItemDetails.PlantId);
                plant.Init(plantItemDetails.FullGrownSprite, m_plantPosition.position, plantItemDetails.PlantSkill);

                m_currentChosenPlantContainer.PlantSeedCount--;
                GameManager.Instance.UIManager.UpdateSeedCount(m_currentChosenPlantContainer.PlantItemDetails.PlantSkill, m_currentChosenPlantContainer.PlantSeedCount);

                if (m_currentChosenPlantContainer.PlantSeedCount <= 0)
                {
                    m_plantContainer.Remove(m_currentChosenPlantContainer);

                    if (m_plantContainer.Count > 0)
                    {
                        m_currentChosenIndexPlantContainer = 0;
                        m_currentChosenPlantContainer = m_plantContainer[m_currentChosenIndexPlantContainer];
                        SetPlantChoiceUI();
                    }
                    else
                    {
                        m_seedIconToChoose.sprite = m_warningNoSeedSign;
                        m_currentChosenIndexPlantContainer = 0;
                        m_angelPlants.SetActive(true);
                    }
                }
            }
            else
            {
                Debug.Log("No Plant Item Get!");
            }
        }

        private void SetPlantChoiceUI()
        {
            m_seedIconToChoose.sprite = m_currentChosenPlantContainer.PlantItemDetails.PlantSproutSprite;
        }

        private void OnChoosePlant()
        {
            if (m_plantContainer.Count > 0)
            {                       
                m_seedIconUI.transform.DOLocalMoveY(m_seedTopAnimationBottomPoint.localPosition.y, 0f);
                m_seedIconUI.transform.DOLocalMoveY(m_seedTopAnimationTopPoint.localPosition.y, 0.1f).OnComplete(() =>
                {
                    m_currentChosenIndexPlantContainer++;
                    if (m_currentChosenIndexPlantContainer >= m_plantContainer.Count)
                    {
                        m_currentChosenIndexPlantContainer = 0;
                    }

                    m_currentChosenPlantContainer = m_plantContainer[m_currentChosenIndexPlantContainer];
                    SetPlantChoiceUI();

                    m_seedIconUI.transform.DOLocalMoveY(m_seedTopAnimationBottomPoint.localPosition.y, 0.1f);
                });
            }
            else
            {
                Debug.Log("No More Seed to Plant!");
            }
        }

        private void OnPlantHold()
        {
            // Debug.Log("Plant on Hol");
            // m_randomPlantItemDetails = GetRandomPlantItemDetails();
            // m_sproutSpriteRenderer.sprite = m_randomPlantItemDetails.PlantSproutSprite;
            // m_playerAnimationController.PlayPlantingAnimation();

            // if (m_isPlanting)
            // {
            //     m_isPlanting = false;
            //     m_playerAnimationController.ResetPlantingAnimation();
            // }
            // else
            // {
            if (m_plantContainer.Count > 0)
            {
                m_sproutSpriteRenderer.sprite = m_currentChosenPlantContainer.PlantItemDetails.PlantSproutSprite;
                m_playerAnimationController.PlayPlantingAnimation();
            }
            else
            {
                Debug.Log("No More Seed to Plant!");
            }
        }

        private PlantItemDetails GetRandomPlantItemDetails()
        {
            var index = Random.Range(0, m_plantItemDetails.Length);
            return m_plantItemDetails[index];
        }
    }
}