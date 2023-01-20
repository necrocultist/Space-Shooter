using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect_", menuName = "Scriptable Objects/Audio/Sound Effect")]
public class SoundEffectSO : ScriptableObject
{
    #region Header SOUND EFFECT DETAILS

    [Space(10)] [Header("SOUND EFFECT DETAILS")]

    #endregion

    public string soundEffectName;

    public AudioClip soundEffectClip;

    [Range(0.1f, 1.5f)] public float soundEffectPitchRandomVariationMin = 0.8f;
    [Range(0.1f, 1.5f)] public float soundEffectPitchRandomVariationMax = 1.5f;
}
