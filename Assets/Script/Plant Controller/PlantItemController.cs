using System.Collections;
using UnityEngine;

namespace Script.Plant_Controller
{
    public class PlantItemController : MonoBehaviour
    {
        private const float TIMER_TO_DISAPPEAR = 10f;
        
        [SerializeField] private SpriteRenderer m_plantSpriteRenderer;
        
        private bool m_isPlanted;
        public bool IsPlanted => m_isPlanted;
        
        public void Init(Sprite p_sprite, Vector2 p_position)
        {
            m_isPlanted = true;
            m_plantSpriteRenderer.sprite = p_sprite;
            transform.position = new Vector2(p_position.x, p_position.y);
            gameObject.SetActive(true);

            StartCoroutine(StartSelfDisappearTimer());
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
