using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDetails_", menuName = "Scriptable Objects/Weapons/Weapon Details")]
public class WeaponDetailsSO : ScriptableObject
{
    #region Header WEAPON BASE DETAILS

    [Space(10)] [Header("WEAPON BASE DETAILS")]

    #endregion Header WEAPON BASE DETAILS

    public string weaponName;

    public Sprite weaponSprite;
    
    #region Header WEAPON CONFIGURATION

    [Space(10)] [Header("WEAPON CONFIGURATION")]

    #endregion Header WEAPON CONFIGURATION

    public Vector3 weaponShootPosition;

    public AmmoDetailsSO weaponCurrentAmmo;
    
    //TODO: 
}