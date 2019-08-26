using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class GUIMusicTransition : MonoBehaviour {
	public AudioMixerSnapshot menuMusic;
	public AudioMixerSnapshot gameplayMusic;
	public float bpm = 128;


	private float m_TransitionIn;
	private float m_TransitionOut;
	private float m_QuarterNote;

	// Use this for initialization
	void Start() {
		m_QuarterNote = 60 / bpm;
		m_TransitionIn = m_QuarterNote;
		m_TransitionOut = m_QuarterNote * 32;
		gameplayMusic.TransitionTo(m_TransitionIn);
	}

	void OnDestroy() {
		menuMusic.TransitionTo(m_TransitionIn);
	}
}
