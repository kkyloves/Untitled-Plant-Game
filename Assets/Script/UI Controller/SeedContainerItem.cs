using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Script.UI_Controller
{
    public class SeedContainerItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_seedCount;

        private void Awake()
        {
            m_seedCount.text = "X" + 5;
        }

        public void UpdateSeedCount(int p_seedCount)
        {
            transform.DOScale(1.2f, 0.2f).OnComplete(() =>
            {
                Debug.Log("count : " + p_seedCount);
                m_seedCount.text = "X" + p_seedCount;
                transform.DOScale(1f, 0.2f);
            });
        }
    }
}
