using System;
using System.Collections;
using Script.Scriptable_Object;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantItemController : MonoBehaviour
    {
        private const float TIMER_TO_DISAPPEAR = 10f;
        
        [SerializeField] private SpriteRenderer m_plantSpriteRenderer;
        [SerializeField] private PlantShooterController m_plantShooterController;
        [SerializeField] private PlantPoisonController m_plantPoisonController;
        
        private bool m_isPlanted;
        public bool IsPlanted => m_isPlanted;

        public void Init(Sprite p_sprite, Vector2 p_position, PlantSkill p_plantSkill)
        {
            m_isPlanted = true;
            
            ActivatePlantEffect(p_plantSkill);
            
            m_plantSpriteRenderer.sprite = p_sprite;
            transform.position = new Vector2(p_position.x, p_position.y);
            
            gameObject.SetActive(true);
            StartCoroutine(StartSelfDisappearTimer());
        }

        private void ActivatePlantEffect(PlantSkill p_plantSkill)
        {
            switch (p_plantSkill)
            {
                case PlantSkill.Shooting:
                    {
                        m_plantShooterController.gameObject.SetActive(true);
                        m_plantPoisonController.gameObject.SetActive(false);
                        
                        m_plantShooterController.Init();
                    }
                    break;
                case PlantSkill.Poison:
                    {
                        m_plantShooterController.gameObject.SetActive(false);
                        m_plantPoisonController.gameObject.SetActive(true);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(p_plantSkill), p_plantSkill, null);
            }
        }

        private IEnumerator StartSelfDisappearTimer()
        {
            yield return new WaitForSeconds(TIMER_TO_DISAPPEAR);
            Disappear();
        }

        public void Disappear()
        {
            m_isPlanted = false;
            gameObject.SetActive(false);
        }
    }
}
