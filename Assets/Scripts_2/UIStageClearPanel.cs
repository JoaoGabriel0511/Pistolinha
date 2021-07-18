using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIStageClearPanel : MonoBehaviour
{
    [SerializeField] List<UIScoreStar> scoreStars = new List<UIScoreStar>();
    [SerializeField] AudioClip victorySFX = null;
    [SerializeField] AudioMixerGroup sfxMixerGroup = null;

    LevelManager levelManager;

    public void LoadLevelSelect() {
		GameManager.Instance.LoadWorld1();
	}

	public void LoadSameLevel() {
		GameManager.Instance.LoadSameLevel();
	}

	public void LoadNextLevel() {
		GameManager.Instance.LoadNextLevel();
	}

    void Start() 
    {
        FindObjectOfType<LevelManager>().StageCleared += OnStageCleared;
		gameObject.SetActive(false);
    }

    void OnStageCleared(int p_score) 
    {
        SetScoreStars(p_score);
        SoundManager.Instance.PlaySFX(victorySFX, sfxMixerGroup);
		gameObject.SetActive(true);
    }

    void SetScoreStars(int p_score) 
    {
        for (int i = 0; i < scoreStars.Count; i++)
        {
            scoreStars[i].SetStar(p_score > i);
        }
    }
}
