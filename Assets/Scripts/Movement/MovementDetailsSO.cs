using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "MovementDetails_", menuName = "Scriptable Objects/Movement/Movement Details")]
public class MovementDetailsSO : ScriptableObject
{
    public float minMoveSpeed = 8f;
    public float maxMoveSpeed = 8f;

    public float GetMoveSpeed()
    {
        if (Math.Abs(maxMoveSpeed - minMoveSpeed) != 0)
        {
            return Random.Range(minMoveSpeed, maxMoveSpeed);
        }
        else
        {
            return minMoveSpeed;
        }
    }

    #region Validation

#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckPositiveRange(this, nameof(minMoveSpeed), minMoveSpeed, nameof(maxMoveSpeed),
            maxMoveSpeed);
    }
#endif

    #endregion
}