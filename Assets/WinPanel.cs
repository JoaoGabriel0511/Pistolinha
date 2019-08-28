using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class WinPanel : MonoBehaviour {
	// Start is called before the first frame update
	private int shootCount;
	void Start() {
		FindObjectOfType<Goal>().StageCleared.AddListener(() => {
			Debug.Log("Acabou sim");
			OnStageCleared();
		});
		gameObject.SetActive(false);
	}

	void OnStageCleared() {
		Debug.Log("ACABOU");
        int level = int.Parse(SceneManager.GetActiveScene().name.Remove(0, "Level".Length));
        shootCount = FindObjectOfType<LevelManager>().GetShootCount();
		if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor1Star()) {
            if (PlayerPrefs.GetInt("Level" + level + "Stars", 0) < 1) {
                PlayerPrefs.SetInt("Level" + level + "Stars", 1);
            }
			gameObject.transform.Find("victory screen").gameObject.transform.Find("Star1").gameObject.SetActive(true);
		}
		if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor2Stars()) {
            if (PlayerPrefs.GetInt("Level" + level + "Stars", 0) < 2) {
                PlayerPrefs.SetInt("Level" + level + "Stars", 2);
            }
            gameObject.transform.Find("victory screen").gameObject.transform.Find("Star2").gameObject.SetActive(true);
		}
		if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor3Stars()) {
            if (PlayerPrefs.GetInt("Level" + level + "Stars", 0) < 3) {
                PlayerPrefs.SetInt("Level" + level + "Stars", 3);
            }
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
		GameManager.Instance.LoadScene("StageSelectionW1");
	}

	public void LoadSameLevel() {
		GameManager.Instance.LoadSameLevel();
	}

	public void LoadNextLevel() {
		GameManager.Instance.LoadNextLevel();
	}
}
