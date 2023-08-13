using System;
using Script.Scriptable_Object;
using UnityEngine;

namespace Script.UI_Controller
{
    public class PlayerSeedContainerController : MonoBehaviour
    {
        [SerializeField] private SeedContainerItem m_squashSeedContainerItem;
        [SerializeField] private SeedContainerItem m_mushroomSeedContainerItem;

        public void UpdateSeedCount(PlantSkill p_plantSkill, int p_seedCount)
        {
            switch (p_plantSkill)
            {
                case PlantSkill.Shooting:
                {
                    m_squashSeedContainerItem.UpdateSeedCount(p_seedCount);
                }
                    break;
                case PlantSkill.Poison:
                {
                    m_mushroomSeedContainerItem.UpdateSeedCount(p_seedCount);
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(p_plantSkill), p_plantSkill, null);
            }
        }
    }
}
