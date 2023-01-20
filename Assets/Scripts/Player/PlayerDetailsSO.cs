using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDetails_", menuName = "Scriptable Objects/Player/Player Details")]
public class PlayerDetailsSO : ScriptableObject
{
    #region Header PLAYER BASE DETAILS

    [Space(10)] [Header("PLAYER BASE DETAILS")]

    #endregion
    public string playerCharacterName;
    public GameObject playerPrefab;
    public RuntimeAnimatorController runtimeAnimatorController;

    #region Header HEALTH

    [Space(10)] [Header("HEALTH")]

    #endregion
    public int playerHealthAmount;
    public bool isImmuneAfterHit = false;
    public float hitImmunityTime;
    
    #region Header Other

    [Space(10)] [Header("Other")]

    #endregion
    public Sprite playerMiniMapIcon;

    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(playerCharacterName), playerCharacterName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerPrefab), playerPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(playerMiniMapIcon), playerMiniMapIcon);
        HelperUtilities.ValidateCheckNullValue(this, nameof(runtimeAnimatorController), runtimeAnimatorController);
    }
#endif

    #endregion

}