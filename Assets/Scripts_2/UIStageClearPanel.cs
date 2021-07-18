using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIStageClearPanel : MonoBehaviour
{
    [SerializeField] List<UIScoreStar> scoreStars = new List<UIScoreStar>();
    [SerializeField] AudioClip victorySFX = null;
    [SerializeField] AudioMixerGroup sfxMixerGroup = null;
    [SerializeField] float timeToShow = 0.5f;
    [SerializeField] GameObject panelBG = null;
    [SerializeField] GameObject panelElements = null;

    LevelManager levelManager;
    bool ended = false;

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
        panelBG.SetActive(false);
        panelElements.SetActive(false);
    }

    void OnStageCleared(int p_score) 
    {
        if (!ended) 
        {
            ended = true;
            StartCoroutine(ShowPanel(p_score));
        }
    }

    IEnumerator ShowPanel(int p_score) 
    {
        yield return new WaitForSeconds(timeToShow);
        SetScoreStars(p_score);
        SoundManager.Instance.PlaySFX(victorySFX, sfxMixerGroup);
		panelBG.SetActive(true);
        panelElements.SetActive(true);
    }

    void SetScoreStars(int p_score) 
    {
        for (int i = 0; i < scoreStars.Count; i++)
        {
            scoreStars[i].SetStar(p_score > i);
        }
    }
}
