using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ActiveWeapon))]
[RequireComponent(typeof(WeaponEvents))]
[DisallowMultipleComponent]
public class FireWeapon : MonoBehaviour
{
    private float firePreChargeTimer = 0f;
    private float fireRateCooldownTimer = 0f;

    private Weapon activeWeapon;
    private WeaponEvents weaponEvents;

    private void Awake()
    {
        activeWeapon = GetComponent<Weapon>();
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

    private void HandleFireWeaponEvent(WeaponEvents weaponEvents, FireWeaponArgs fireWeaponeventArgs)
    {
        WeaponFire(fireWeaponeventArgs);
    }

    private void WeaponFire(FireWeaponArgs fireWeaponeventArgs)
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

    private void WeaponPreCharge(FireWeaponArgs fireWeaponeventArgs)
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
        firePreChargeTimer = activeWeapon.weaponDetails.weaponPrechargeTime;
    }

    private bool IsWeaponReadyToFire()
    {
        
        if (activeWeapon.weaponRemainingAmmo <= 0 &&
            !activeWeapon.weaponDetails.hasInfiniteAmmo) return false;

        if (activeWeapon.isWeaponReloading) return false;

        // If the weapon isn't precharged or is cooling down then return false.
        if (firePreChargeTimer > 0f || fireRateCooldownTimer > 0f) return false;

        if (activeWeapon.weaponClipRemainingAmmo <= 0 &&
            !activeWeapon.weaponDetails.hasInfiniteClipCapacity)
        {
            weaponEvents.CallReloadWeaponEvent(activeWeapon, 0);
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
        int ammoPerShot = Random.Range(currentAmmo.ammoSpawnAmountMin, currentAmmo.ammoSpawnAmountMax + 1);
        float ammoSpawnInterval = 0f;
            
        if (ammoPerShot > 1)
        {
            ammoSpawnInterval = Random.Range(currentAmmo.ammoSpawnAmountMin, currentAmmo.ammoSpawnAmountMax);
        }
        //StartCoroutine(activeWeapon.FireAmmoRoutine(currentAmmo,weaponAimDirection));

        while (ammoCount < ammoPerShot)
        {
            GameObject ammoPrefab = currentAmmo.ammoPrefabArray[Random.Range(0, currentAmmo.ammoPrefabArray.Length)];

            float ammoSpeed = Random.Range(currentAmmo.ammoSpeedMin, currentAmmo.ammoSpawnAmountMax);

            IFireable ammo = PoolManager.Instance.ReuseComponent(ammoPrefab, activeWeapon.GetShootPosition(),
                Quaternion.identity) as IFireable;

            ammo?.InitializeAmmo(currentAmmo, ammoSpeed);

            ammoCount++;

            yield return new WaitForSeconds(ammoSpawnInterval);
        }
        
        if (!activeWeapon.weaponDetails.hasInfiniteClipCapacity)
        {
            activeWeapon.weaponClipRemainingAmmo--;
            activeWeapon.weaponRemainingAmmo--;
        }
        
        weaponEvents.CallWeaponFiredEvent(activeWeapon);

        WeaponShootEffect();
        WeaponSoundEffect();
    }

    private void WeaponShootEffect()
    {
        throw new System.NotImplementedException();
    }
    
    private void WeaponSoundEffect()
    {
        if (activeWeapon.weaponDetails.weaponFireSoundEffect != null)
        {
            SoundEffectManager.Instance.PlaySoundEffect(activeWeapon.weaponDetails.weaponFireSoundEffect);
        }
    }
}