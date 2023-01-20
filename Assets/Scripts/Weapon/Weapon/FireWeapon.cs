using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ActiveWeapon))]
[RequireComponent(typeof(WeaponEvents))]
[DisallowMultipleComponent]
public class FireWeapon : MonoBehaviour
{
    private float firePreChargeTimer = 0f;
    private float fireRateCooldownTimer = 0f;

    private ActiveWeapon activeWeapon;
    private WeaponEvents weaponEvents;

    private void Awake()
    {
        activeWeapon = GetComponent<ActiveWeapon>();
        weaponEvents = GetComponent<WeaponEvents>();
    }

    private void OnEnable()
    {
        weaponEvents.OnFireWeapon += HandleFireWeaponEvent;
    }

    private void OnDisable()
    {
        weaponEvents.OnFireWeapon -= HandleFireWeaponEvent;
    }

    private void HandleFireWeaponEvent(WeaponEvents weaponEvents, FireWeaponEventArgs fireWeaponeventArgs)
    {
        WeaponFire(fireWeaponeventArgs);
    }

    private void WeaponFire(FireWeaponEventArgs fireWeaponeventArgs)
    {
        WeaponPreCharge(fireWeaponeventArgs);

        if (fireWeaponeventArgs.fire)
        {
            if (IsWeaponReadyToFire())
            {
                FireAmmo(fireWeaponeventArgs.weaponAimDirection);
            }
        }
    }

    private void WeaponPreCharge(FireWeaponEventArgs fireWeaponeventArgs)
    {
        if (fireWeaponeventArgs.firePreviousFrame)
        {
            // Decrease precharge timer if fire button held previous frame.
            firePreChargeTimer -= Time.deltaTime;
        }
        else
        {
            ResetPreChargeTimer();
        }
    }

    private void ResetPreChargeTimer()
    {
        firePreChargeTimer = activeWeapon.GetCurrentWeapon().weaponDetails.weaponPrechargeTime;
    }

    private bool IsWeaponReadyToFire()
    {
        if (activeWeapon.GetCurrentWeapon().weaponRemainingAmmo <= 0 &&
            !activeWeapon.GetCurrentWeapon().weaponDetails.hasInfiniteAmmo) return false;

        if (activeWeapon.GetCurrentWeapon().isWeaponReloading) return false;

        // If the weapon isn't precharged or is cooling down then return false.
        if (firePreChargeTimer > 0f || fireRateCooldownTimer > 0f) return false;

        if (activeWeapon.GetCurrentWeapon().weaponClipRemainingAmmo <= 0 &&
            !activeWeapon.GetCurrentWeapon().weaponDetails.hasInfiniteClipCapacity)
        {
            weaponEvents.CallReloadWeaponEvent(activeWeapon.GetCurrentWeapon(), 0);
        }

        return true;
    }

    private void FireAmmo(Vector3 weaponAimDirection)
    {
        AmmoDetailsSO currentAmmo = activeWeapon.GetCurrentAmmo();

        if (currentAmmo != null)
        {
            StartCoroutine(FireAmmoRoutine(currentAmmo, weaponAimDirection));
        }
    }

    private IEnumerator FireAmmoRoutine(AmmoDetailsSO currentAmmo, Vector3 weaponAimDirection)
    {
        int ammoCount = 0;
        
    }
}