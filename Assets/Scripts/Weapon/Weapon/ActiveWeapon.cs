using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponShootPositionTransform;
    [SerializeField] private Transform weaponEffectPositionTransform;

    private WeaponEvents weaponEvents;
    private Weapon currentWeapon;


    private void Awake()
    {
        weaponEvents = GetComponent<WeaponEvents>();
    }

}
