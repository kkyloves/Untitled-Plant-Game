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
            m_seedCount.text = "X2";
        }

        public void UpdateSeedCount(int p_seedCount)
        {
            transform.DOScale(1.2f, 0.2f).OnComplete(() =>
            {
                m_seedCount.text = "X" + p_seedCount;
                transform.DOScale(1f, 0.2f);
            });
        }
    }
}
