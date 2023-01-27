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

    public Vector3[] weaponShootPosition;

    public AmmoDetailsSO weaponCurrentAmmo;

    public SoundEffectSO weaponFireSoundEffect;
    public SoundEffectSO weaponReloadSoundEffect;

    public bool hasInfiniteAmmo = false;
    public bool hasInfiniteClipCapacity = false;

    public int weaponClipAmmoCapacity = 12;
    public int weaponAmmoCapacity = 100;

    public float weaponFireRate;
    public float weaponReloadTime;

    #region Validation

#if UNITY_EDITOR

    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(weaponName), weaponName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponCurrentAmmo), weaponCurrentAmmo);
    }

#endif

    #endregion Validation
}