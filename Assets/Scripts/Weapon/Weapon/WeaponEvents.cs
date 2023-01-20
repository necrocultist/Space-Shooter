using System;
using UnityEngine;

[DisallowMultipleComponent]
public class 
    WeaponEvents : MonoBehaviour
{
    public event Action<WeaponEvents, FireWeaponEventArgs> OnFireWeapon;
    public event Action<WeaponEvents, WeaponFiredEventArgs> OnWeaponFired;
    public event Action<WeaponEvents, ReloadWeaponArgs> OnReloadWeapon;
    public event Action<WeaponEvents, WeaponReloadedEventArgs> OnWeaponReloaded;

    public void CallFireWeaponEvent(bool fire, Vector3 weaponAimDirection, bool firePreviousFrame)
    {
        OnFireWeapon?.Invoke(this,
            new FireWeaponEventArgs()
                { fire = fire, weaponAimDirection = weaponAimDirection, firePreviousFrame = firePreviousFrame });
    }

    public void CallWeaponFired(Weapon weapon)
    {
        OnWeaponFired?.Invoke(this, new WeaponFiredEventArgs(){ weapon = weapon});
    }
    
    public void CallReloadWeaponEvent(Weapon weapon, int reloadAmmoPercent)
    {
        OnReloadWeapon?.Invoke(this, new ReloadWeaponArgs() { weapon = weapon, reloadAmmoPercent = reloadAmmoPercent });
    }

    public void CallWeaponReloadedEvent(Weapon weapon)
    {
        OnWeaponReloaded?.Invoke(this, new WeaponReloadedEventArgs() { weapon = weapon });
    }
}

public class FireWeaponEventArgs : EventArgs
{
    public bool fire;
    public Vector3 weaponAimDirection;
    public bool firePreviousFrame;
}

public class WeaponFiredEventArgs : EventArgs
{
    public Weapon weapon;
}

public class ReloadWeaponArgs : EventArgs
{
    public Weapon weapon;
    public int reloadAmmoPercent;
}

public class WeaponReloadedEventArgs : EventArgs
{
    public Weapon weapon;
}