using UnityEngine;

public static class Settings
{
    #region AUDIO
    public const float musicFadeOutTime = 0.5f;  // Defualt Music Fade Out Transition
    public const float musicFadeInTime = 0.5f;  // Default Music Fade In Transition
    #endregion
    
    #region HIGHSCORES
    public const int numberOfHighScoresToSave = 100;
    #endregion
    
    #region ENEMY PARAMETERS
    public const int defaultEnemyHealth = 20;
    #endregion

    #region PLAYER
    public static float baseSpeedForPlayerAnimations = 8f;
    public static KeyCode playerShootButton = KeyCode.Z;
    public static KeyCode playerTeleportButton = KeyCode.X;
    #endregion

    #region Other
    public const float contactDamageCollisionResetDelay = 0.5f;
    #endregion
}
