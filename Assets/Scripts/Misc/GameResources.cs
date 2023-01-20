using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameResources : MonoBehaviour
{
    private static GameResources instance;

    public static GameResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<GameResources>("GameResources");
            }

            return instance;
        }
    }

    #region Header PLAYER

    [Space(10)] [Header("PLAYER")]

    #endregion
    public List<PlayerDetailsSO> playerDetailsList;
    public CurrentPlayerSO currentPlayer;
    
    #region Header MUSIC

    [Space(10)]
    [Header("Music")]

    #endregion
    #region Tooltip

    [Tooltip("Populate with the music master mixer group")]

    #endregion
    public AudioMixerGroup musicMasterMixerGroup;
    #region Tooltip

    [Tooltip("Main menu music scriptable object")]

    #endregion Tooltip
    public MusicTrackSO mainMenuMusic;
    #region Tooltip

    [Tooltip("music on full snapshot")]

    #endregion Tooltip
    public AudioMixerSnapshot musicOnFullSnapShot;
    #region Tooltip

    [Tooltip("music low snapshot")]

    #endregion Tooltip
    public AudioMixerSnapshot musicLowSnapShot;
}