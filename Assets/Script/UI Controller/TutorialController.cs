using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Script.UI_Controller
{
    public class TutorialController : MonoBehaviour
    {
        private const float TUTORIAL_TIMER_TO_DISAPPEAR = 8f;
        private CanvasGroup m_canvasGroup;

        private void Awake()
        {
            m_canvasGroup = GetComponent<CanvasGroup>();
            StartCoroutine(StatTutorialTimer());
        }

        private IEnumerator StatTutorialTimer()
        {
            yield return new WaitForSeconds(TUTORIAL_TIMER_TO_DISAPPEAR);
            m_canvasGroup.DOFade(0f, 5f);
        }
        
    }
}
