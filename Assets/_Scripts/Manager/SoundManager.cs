using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundFxAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        SetInitialVolume();
    }

    private void SetInitialVolume()
    {
        musicAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        soundFxAudioSource.volume = PlayerPrefs.GetFloat("SoundFxVolume", 0.5f);
    }

    public void PlaySoundFx(AudioClip audioClip)
    {
        soundFxAudioSource.PlayOneShot(audioClip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void ChangeMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeSoundFxVolume(float volume)
    {
        soundFxAudioSource.volume = volume;
        PlayerPrefs.SetFloat("SoundFxVolume", volume);
    }

}
