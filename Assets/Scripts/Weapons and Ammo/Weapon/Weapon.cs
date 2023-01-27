using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponEvents))]
[DisallowMultipleComponent]
public abstract class Weapon : MonoBehaviour
{
    #region Tooltip
    [Tooltip("Add the SpriteRenderer on the child Weapon gameobject")]
    #endregion
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    #region Tooltip
    [Tooltip("Add the PolygonCollider2D on the child Weapon gameobject")]
    #endregion
    [SerializeField] private PolygonCollider2D weaponPolygonCollider2D;
    #region Tooltip
    [Tooltip("Add the Transform on the WeaponShootPosition gameobject")]
    #endregion
    [SerializeField] private Transform weaponShootPositionTransform;
    #region Tooltip
    [Tooltip("Add the Transform on the WeaponEffectPosition gameobject")]
    #endregion
    [SerializeField] private Transform weaponEffectPositionTransform;

    private WeaponEvents weaponEvents;
    
    public WeaponDetailsSO weaponDetails;
    public float weaponReloadTimer;
    public int weaponClipRemainingAmmo;
    public int weaponRemainingAmmo;
    public bool isWeaponReloading;

    public AmmoDetailsSO GetCurrentAmmo()
    {
        return weaponDetails.weaponCurrentAmmo;
    }

    public Vector3 GetShootPosition()
    {
        return weaponShootPositionTransform.position;
    }
    
    public Vector3 GetShootEffectPosition()
    {
        return weaponEffectPositionTransform.position;
    }

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponSpriteRenderer), weaponSpriteRenderer);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponPolygonCollider2D), weaponPolygonCollider2D);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponShootPositionTransform), weaponShootPositionTransform);
        HelperUtilities.ValidateCheckNullValue(this, nameof(weaponEffectPositionTransform), weaponEffectPositionTransform);
    }
#endif
    #endregion
    
}
