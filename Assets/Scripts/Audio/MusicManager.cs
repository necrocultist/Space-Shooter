using System.Collections;
using UnityEngine;

public class MusicManager : SingletonMonoBehaviour<MusicManager>
{
    private AudioSource musicAudioSource;
    private AudioClip currentAudioClip;
    private Coroutine fadeOutCoroutine;
    private Coroutine fadeInCoroutine;

    [SerializeField] private int musicVolume = 10;

    protected override void Awake()
    {
        base.Awake();

        // Load components
        musicAudioSource = GetComponent<AudioSource>();

        // TODO: Start with music off
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicVolume = PlayerPrefs.GetInt("musicVolume");
        }

        SetMusicVolume(musicVolume);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("musicVolume", musicVolume);
    }

    public void PlayMusic(MusicTrackSO musicTrack, float fadeOutTime = Settings.musicFadeOutTime,
        float fadeInTime = Settings.musicFadeInTime)
    {
        StartCoroutine(PlayMusicRoutine(musicTrack, fadeOutTime, fadeInTime));
    }

    private IEnumerator PlayMusicRoutine(MusicTrackSO musicTrack, float fadeOutTime, float fadeInTime)
    {
        if (fadeOutCoroutine != null)
        {
            StopCoroutine(fadeOutCoroutine);
        }

        if (fadeInCoroutine != null)
        {
            StopCoroutine(fadeInCoroutine);
        }

        if (musicTrack.musicCLip != currentAudioClip)
        {
            currentAudioClip = musicTrack.musicCLip;

            yield return fadeOutCoroutine = StartCoroutine(FadeOutMusic(fadeOutTime));
            yield return fadeOutCoroutine = StartCoroutine(FadeInMusic(musicTrack, fadeInTime));
        }

        yield return null;
    }

    private IEnumerator FadeOutMusic(float fadeOutTime)
    {
        GameResources.Instance.musicLowSnapShot.TransitionTo(fadeOutTime);
        yield return new WaitForSeconds(fadeOutTime);
    }

    private IEnumerator FadeInMusic(MusicTrackSO musicTrack, float fadeInTime)
    {
        musicAudioSource.clip = musicTrack.musicCLip;
        musicAudioSource.volume = musicTrack.musicVolume;
        musicAudioSource.Play();
        GameResources.Instance.musicOnFullSnapShot.TransitionTo(fadeInTime);
        yield return new WaitForSeconds(fadeInTime);
    }

    public void IncreaseMusicVolume()
    {
        const int maxMusicVolume = 20;

        if (musicVolume >= maxMusicVolume) return;

        musicVolume += 1;

        SetMusicVolume(musicVolume);
    }

    public void DecreaseMusicVolume()
    {
        if (musicVolume == 0) return;

        musicVolume -= 1;

        SetMusicVolume(musicVolume);
    }

    private void SetMusicVolume(int musicVolume)
    {
        const float muteDecibels = -80f;

        if (musicVolume == 0)
        {
            GameResources.Instance.musicMasterMixerGroup.audioMixer.SetFloat("musicVolume", muteDecibels);
        }
        else
        {
            GameResources.Instance.musicMasterMixerGroup.audioMixer.SetFloat("musicVolume",
                HelperUtilities.LinearToDecibels(musicVolume));
        }
    }
}