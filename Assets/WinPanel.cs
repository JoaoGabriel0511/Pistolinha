using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class WinPanel : MonoBehaviour {
	private int shootCount;
	void Start() {
		FindObjectOfType<Goal>().StageCleared.AddListener(() => {
			OnStageCleared();
		});
		gameObject.SetActive(false);
	}

	void OnStageCleared() {
		shootCount = FindObjectOfType<LevelManager>().GetShootCount();
		if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor1Star()) {
			gameObject.transform.Find("victory screen").gameObject.transform.Find("Star1").gameObject.SetActive(true);
		}
		if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor2Stars()) {
			gameObject.transform.Find("victory screen").gameObject.transform.Find("Star2").gameObject.SetActive(true);
		}
		if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor3Stars()) {
			gameObject.transform.Find("victory screen").gameObject.transform.Find("Star3").gameObject.SetActive(true);
		}
		TextMeshProUGUI textMeshPro = gameObject.transform.Find("TotalShoots").gameObject.GetComponent<TextMeshProUGUI>();
		Debug.Log(textMeshPro);
		textMeshPro.text = "Shoots: " + shootCount;
		gameObject.SetActive(true);
	}

	void OnFinishedOpening() {

	}

	public void LoadMap() {
		GameManager.Instance.LoadWorld1();
	}

	public void LoadSameLevel() {
		GameManager.Instance.LoadSameLevel();
	}

	public void LoadNextLevel() {
		GameManager.Instance.LoadNextLevel();
	}
}
