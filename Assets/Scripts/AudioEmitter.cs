using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitter : MonoBehaviour
{
    FMOD.Studio.PLAYBACK_STATE previousState = FMOD.Studio.PLAYBACK_STATE.STOPPED, currentState = FMOD.Studio.PLAYBACK_STATE.STOPPED;
    [FMODUnity.EventRef] [SerializeField] string[] selectSound;
    FMOD.Studio.EventInstance[] soundEvent;
    int index = 0;

    // Start is called before the first frame update
    void Awake()
    {
        soundEvent = new FMOD.Studio.EventInstance[selectSound.Length];
    }

    void Start()
    {
        if(selectSound.Length != 0 || selectSound[index] != "")
            soundEvent[index] = FMODUnity.RuntimeManager.CreateInstance(selectSound[index]);
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEvent[index], GetComponent<Transform>(), GetComponent<Rigidbody>());
        soundEvent[index].getPlaybackState(out currentState);
    }

    public void PlaySound()
    {
        soundEvent[index].start();
        soundEvent[index].getPlaybackState(out previousState);
    }

    public void StopAllSounds()
    {
        FMOD.Studio.PLAYBACK_STATE state;
        for(int i = 0; i < selectSound.Length; i++)
        {
            soundEvent[i].getPlaybackState(out state);
            if (state == FMOD.Studio.PLAYBACK_STATE.PLAYING ||
                state == FMOD.Studio.PLAYBACK_STATE.STARTING)
                soundEvent[i].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public void ChangeSound(int index)
    {
        this.index = index;
        if(0 <= index && index <= selectSound.Length)
            soundEvent[index] = FMODUnity.RuntimeManager.CreateInstance(selectSound[index]);
    }

    public bool FinishedPlaying()
    {
        return currentState == FMOD.Studio.PLAYBACK_STATE.STOPPED &&
                (previousState == FMOD.Studio.PLAYBACK_STATE.PLAYING || 
                 previousState == FMOD.Studio.PLAYBACK_STATE.STARTING);
    }
}
