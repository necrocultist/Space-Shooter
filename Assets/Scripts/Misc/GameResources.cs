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
    public AudioMixerGroup musicMasterMixerGroup;
    public MusicTrackSO mainMenuMusic;
    public AudioMixerSnapshot musicOnFullSnapShot;
    public AudioMixerSnapshot musicOffSnapshot;
    public AudioMixerSnapshot musicLowSnapShot;
    
    #region Header UI
    [Space(10)]
    [Header("UI")]
    #endregion
    public GameObject heartPrefab;
    public GameObject scorePrefab;
}