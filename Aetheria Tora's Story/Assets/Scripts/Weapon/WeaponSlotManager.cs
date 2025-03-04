using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    Animator animator;
    PlayerStats playerStats;

    public WeaponItem attackingWeapon; 
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();

        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            //leftHandSlot.LoadWeaponModel(weaponItem);
            //LoadLeftWeaponDamageCollider();

            #region Handle Left Weapon Idle Animation
            //if (weaponItem != null)
            //{
            //    animator.CrossFade(weaponItem.Left_Arm_Idle_01, 0.2f);
            //}
            //else
            //{
            //    animator.CrossFade("Left Arm Empty", 0.2f);
            //}
            #endregion
        }
        else
        {
          //  rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponDamageCollider();

            #region Handle Right Weapon Idle Animation
            if (weaponItem != null)
            {
                animator.CrossFade(weaponItem.Right_Arm_Idle_01, 0.2f);
            }
            else
            {
                animator.CrossFade("Right Arm Empty", 0.2f);
            }
            #endregion
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, int index)
    {
        rightHandSlot.LoadWeapon(index);
        LoadRightWeaponDamageCollider();

        #region Handle Right Weapon Idle Animation
        if (weaponItem != null)
        {
            animator.CrossFade(weaponItem.Right_Arm_Idle_01, 0.2f);
        }
        else
        {
            animator.CrossFade("Right Arm Empty", 0.2f);
        }
        #endregion
    }

    #region Handle Weapon's Damage Collider

    private void LoadLeftWeaponDamageCollider()
    {
       // leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightWeaponDamageCollider()
    {
        rightHandDamageCollider = rightHandSlot.spearModel.GetComponentInChildren<DamageCollider>();
    }

    public void OpenRightHandDamageCollider()
    {
        rightHandDamageCollider.EnableDamageCollider();
    }

    public void OpenLeftHandDamageCollider()
    {
        leftHandDamageCollider.EnableDamageCollider();
    }

    public void CloseRightHandDamageCollider()
    {
        rightHandDamageCollider.DisableDamageCollider();
    }

    public void CloseLeftHandDamageCollider()
    {
        leftHandDamageCollider.DisableDamageCollider();
    }

    #endregion

    #region Handle Weapon's Stamina Drainage
    public void DrainStaminaLightAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }

    public void DrainStaminaHeavyAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }
    #endregion
}