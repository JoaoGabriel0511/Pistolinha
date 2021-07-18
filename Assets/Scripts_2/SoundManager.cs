using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioMixerSnapshot menuAudioSnapshot = null;
	[SerializeField] AudioMixerSnapshot gameplayAudioSnapshot = null;
    [SerializeField] float snapshotTransitionTime = 0.5f;

    Dictionary<AudioMixerGroup, AudioSource> audioSourceDictionary = new Dictionary<AudioMixerGroup, AudioSource>();

    void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicated singleton!");
        }
    }

    public void ChangeToMenuSnapShot() 
    {
        menuAudioSnapshot.TransitionTo(snapshotTransitionTime);
    }

    public void ChangeToGameplaySnapshot()
    {
        gameplayAudioSnapshot.TransitionTo(snapshotTransitionTime);
    }

    public void PlaySFX(AudioClip p_sfx, AudioMixerGroup p_audioGroup, float p_volume = 1) 
    {
        GetAudioSource(p_audioGroup).PlayOneShot(p_sfx, p_volume);
    }

    public void PlayMusic(AudioClip p_music, AudioMixerGroup p_audioGroup, float p_volume = 1)
    {
        AudioSource __audioSource = GetAudioSource(p_audioGroup);
        __audioSource.clip = p_music;
        __audioSource.volume = p_volume;
        __audioSource.Play();
    }

    public void StopMusic(AudioMixerGroup p_audioGroup)
    {
        GetAudioSource(p_audioGroup).Stop();
    }

    AudioSource GetAudioSource(AudioMixerGroup p_audioGroup) 
    {
        if (audioSourceDictionary.ContainsKey(p_audioGroup)) 
        {
            return audioSourceDictionary[p_audioGroup];
        }
        else
        {
            AudioSource __newAudioSource = gameObject.AddComponent<AudioSource>();
            __newAudioSource.outputAudioMixerGroup = p_audioGroup;
            audioSourceDictionary.Add(p_audioGroup, __newAudioSource);
            return __newAudioSource;
        }
    }
}
