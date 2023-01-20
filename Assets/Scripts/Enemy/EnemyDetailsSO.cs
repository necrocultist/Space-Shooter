using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails_", menuName = "Scriptable Objects/Enemy/Enemy Details")]
public class EnemyDetailsSO : ScriptableObject
{
    #region Header BASE ENEMY DETAILS

    [Space(10)] [Header("BASE ENEMY DETAILS")]

    #endregion

    public string enemyName;

    public GameObject enemyPrefab;

    public float fireIntervalMin = 0.1f;
    public float fireIntervalMax = 1f;
    public float fireDurationMin = 1f;
    public float fireDurationMax = 2f;

    public int enemyHealthAmount;
    public bool isImmuneAfterHit;
    public float hitImmunityTime;

    public bool isHealthBarDisplayed = false;
    
    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(enemyName), enemyName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(enemyPrefab), enemyPrefab);
    }

#endif

    #endregion
}