using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect_", menuName = "Scriptable Objects/Audio/Sound Effect")]
public class SoundEffectSO : ScriptableObject
{
    #region Header SOUND EFFECT DETAILS

    [Space(10)] [Header("SOUND EFFECT DETAILS")]

    #endregion
    public string soundEffectName;
    public GameObject soundPrefab;
    public AudioClip soundEffectClip;

    [Range(0.1f, 1.5f)] public float soundEffectPitchRandomVariationMin = 0.8f;
    [Range(0.1f, 1.5f)] public float soundEffectPitchRandomVariationMax = 1.5f;
    [Range(0.1f, 1f)] public float soundEffectVolume = 1f;

    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEmptyString(this, nameof(soundEffectName), soundEffectName);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundPrefab), soundPrefab);
        HelperUtilities.ValidateCheckNullValue(this, nameof(soundEffectClip), soundEffectClip);
    }
#endif

    #endregion
}