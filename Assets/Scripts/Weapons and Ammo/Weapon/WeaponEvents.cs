using System;
using UnityEngine;

[DisallowMultipleComponent]
public class
    WeaponEvents : MonoBehaviour
{
    public event Action<WeaponEvents, SetActiveWeaponArgs> OnSetActiveWeapon;
    public event Action<WeaponEvents, FireWeaponArgs> OnFireWeapon;
    public event Action<WeaponEvents, WeaponFiredArgs> OnWeaponFired;
    public event Action<WeaponEvents, ReloadWeaponArgs> OnReloadWeapon;
    public event Action<WeaponEvents, WeaponReloadedArgs> OnWeaponReloaded;

    public void CallSetActiveWeaponEvent(Weapon weapon)
    {
        OnSetActiveWeapon?.Invoke(this, new SetActiveWeaponArgs() { weapon = weapon });
    }

    public void CallFireWeaponEvent(bool fire, Vector3 weaponAimDirection, bool firePreviousFrame)
    {
        OnFireWeapon?.Invoke(this,
            new FireWeaponArgs()
                { fire = fire, weaponAimDirection = weaponAimDirection, firePreviousFrame = firePreviousFrame });
    }

    public void CallWeaponFiredEvent(Weapon weapon)
    {
        OnWeaponFired?.Invoke(this, new WeaponFiredArgs() { weapon = weapon });
    }

    public void CallReloadWeaponEvent(Weapon weapon, int reloadAmmoPercent)
    {
        OnReloadWeapon?.Invoke(this, new ReloadWeaponArgs() { weapon = weapon, reloadAmmoPercent = reloadAmmoPercent });
    }

    public void CallWeaponReloadedEvent(Weapon weapon)
    {
        OnWeaponReloaded?.Invoke(this, new WeaponReloadedArgs() { weapon = weapon });
    }
}

public class SetActiveWeaponArgs : EventArgs
{
    public Weapon weapon;
}

public class FireWeaponArgs : EventArgs
{
    public bool fire;
    public Vector3 weaponAimDirection;
    public bool firePreviousFrame;
}

public class WeaponFiredArgs : EventArgs
{
    public Weapon weapon;
}

public class ReloadWeaponArgs : EventArgs
{
    public Weapon weapon;
    public int reloadAmmoPercent;
}

public class WeaponReloadedArgs : EventArgs
{
    public Weapon weapon;
}