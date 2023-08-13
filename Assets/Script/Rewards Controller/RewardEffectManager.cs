using Script.Loot_Controller;
using Script.Managers;
using Script.Monster_Controller;
using Script.Plant_Controller;
using Script.Player_Controller;
using UnityEngine;

namespace Script.Rewards_Controller
{
    public class RewardEffectManager : MonoBehaviour
    {
        //squash related rewards
        private bool m_isProjectile;
        private float m_shootTimer = 0.8f;
        private float m_squashBulletDamage = 20f;
        
        //mushroom related rewards
        private float m_poisonRange = 5f;
        private float m_poisonDamage = 5f;
        
        //monster related rewards
        private float m_movementPoisonSlowEffect = 2f;
        
        //loot related rewards
        private float m_healEffect = 30f;
        
        //player related rewards
        private float m_moveSpeed = 5f;
        private float m_plantAnimationSpeed = 1f;
        
        public void TurnOnProjectileEffect()
        {
            m_isProjectile = true;
        }

        public void MakeShootTimerFaster()
        {
            m_shootTimer -= 0.1f;
        }

        public void AddSquashBulletDamage()
        {
            m_squashBulletDamage += 10;
        }

        public void AddPoisonRange()
        {
            m_poisonRange += 0.1f;
        }

        public void AddPoisonDamage()
        {
            m_poisonDamage += 5f;
        }

        public void AddSlowPoison()
        {
            m_movementPoisonSlowEffect += 0.5f;
        }

        public void AddHealEffect()
        {
            m_healEffect += 10f;
        }

        public void AddMoveSpeed()
        {
            m_moveSpeed += 1.5f;
        }

        public void AddPlantSpeed()
        {
            m_plantAnimationSpeed += 0.3f;
        }
        
        
        //update the rewards
        public void UpdateSquash(PlantShooterController p_plantShooterController)
        {
            p_plantShooterController.SetProjectileEffect(m_isProjectile);
            p_plantShooterController.SetShootTimerFaster(m_shootTimer);
            p_plantShooterController.SetDamage(m_squashBulletDamage);
        }

        public void UpdateMushroom(PlantPoisonController p_plantPoisonController)
        {
            p_plantPoisonController.SetDamage(m_poisonDamage);
            p_plantPoisonController.SetRange(m_poisonRange);
        }

        public void UpdateMonster(MonsterMovementController p_monsterMovementController)
        {
            p_monsterMovementController.SetSlowEffect(m_movementPoisonSlowEffect);
        }

        public void UpdateLoot(LootItemController p_lootItemManager)
        {
            p_lootItemManager.SetHealEffect(m_healEffect);
        }

        public void UpdatePlayer(PlayerGeneralController p_playerGeneralController)
        {
            p_playerGeneralController.SetMovementSpeed(m_moveSpeed);
            p_playerGeneralController.SetPlayerPlantAnimationSpeed(m_plantAnimationSpeed);
        }

        public void AddLootChance(string p_lootId)
        {
            GameManager.Instance.LootItemManager.AddLootChance(p_lootId);
        }
    }
}
