using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    const string MIXER_MASTER_GROUP_VOLUME = "MasterVolume";

    public static SoundManager Instance;

    [SerializeField] AudioMixer gameAudioMixer = null;
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

    void Start () 
    {
        SetMasterVolume(SaveManager.Instance.GetMasterVolume());
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

    public void SetMasterVolume(float p_volume) 
    {
        p_volume = Mathf.Clamp01(p_volume);
        gameAudioMixer.SetFloat(MIXER_MASTER_GROUP_VOLUME, ConvertVolume2DB(p_volume));
        SaveManager.Instance.SetMasterVolume(p_volume);
    }

    public float GetMasterVolume() 
    {
        float __db;
        gameAudioMixer.GetFloat(MIXER_MASTER_GROUP_VOLUME, out __db);
        return ConvertDB2Volume(__db);
    }

    public float ConvertVolume2DB(float p_volume) 
    {
        float __db = 0;
        if (p_volume >= 0.5f) 
        {
            float __ratio = (p_volume - 0.5f) / 0.5f;
            __ratio = __ratio * __ratio;
            __db = __ratio * 20;
        }
        else
        {
            float __ratio = (0.5f - p_volume) / 0.5f;
            __ratio = __ratio * __ratio;
            __db = __ratio * -80;
        }
        return __db;
    }

    public float ConvertDB2Volume(float p_db) 
    {
        float __volume = 0;
        if (p_db >= 0) 
        {
            float __ratio = p_db / 20;
            __ratio = Mathf.Sqrt(__ratio);
            __volume = 0.5f + __ratio * 0.5f;
        }
        else
        {
            float __ratio = p_db / -80;
            __ratio = Mathf.Sqrt(__ratio);
            __volume = 0.5f - __ratio * 0.5f;
        }
        return __volume;
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
