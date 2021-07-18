using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	const int MAX_LEVEL = 10;
	
	public static GameManager Instance;
	public int CurrentLevel => currentLevel;

	[SerializeField] GameObject loadingScreenObject = null;
	int currentLevel;
	bool redirectToCredits = false;

	void Awake() {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Debug.LogWarning("Two instances of GameManager! Destroying gameObject");
			Destroy(gameObject);
		}
	}

	void Start() {
#if UNITY_ANDROID
		Debug.Log("Android");
		Screen.SetResolution(540, 960, false);
#elif UNITY_STANDALONE_WIN
		Debug.Log("Windows");
		Screen.SetResolution(360, 640, false);
#else
		Debug.Log("Other platforms");
		Screen.SetResolution(360, 640, false);
#endif

		currentLevel = SaveManager.Instance.GetUnlockedLevel() > MAX_LEVEL ? MAX_LEVEL : SaveManager.Instance.GetUnlockedLevel();
		loadingScreenObject.SetActive(true);
		SceneManager.sceneLoaded += OnSceneLoaded;
		SceneManager.LoadScene("TitleScreen", LoadSceneMode.Additive);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		loadingScreenObject.SetActive(false);
		if (scene.name != "GameGUI") SceneManager.SetActiveScene(scene); // Prevent the manager scene from being unloaded when loading a new scene.
	}

	public void StartGame() { // Start game button.
		LoadScene("StageSelectionW1");
	}

	#region Scene loading

	public void LoadScene(string scene) {
		UnloadActiveScene();
		if (scene.Contains("Level")) {
			int __level;
			int.TryParse(scene.Remove(0, "Level".Length), out __level);
			currentLevel = __level;
			SceneManager.LoadScene("GameGUI", LoadSceneMode.Additive);
			SceneManager.LoadScene(scene, LoadSceneMode.Additive);
		}
		else {
			if (redirectToCredits) 
			{
				redirectToCredits = false;
				SaveManager.Instance.SetShowedGameConclusion(true);
				LoadCredits();
				return;
			}
			SceneManager.LoadScene(scene, LoadSceneMode.Additive);
		}
	}

	public void UnloadActiveScene() {
		Scene scene = SceneManager.GetActiveScene();
		if (scene.buildIndex == 0) return;

		if (scene.name.Contains("Level")) {
			SceneManager.UnloadSceneAsync("GameGUI");
		}
		SceneManager.UnloadSceneAsync(scene.buildIndex);
	}

	#endregion

	#region Load specific scene

	public void LoadSameLevel() {
		LoadScene("Level" + CurrentLevel.ToString());
	}
	
	public void LoadNextLevel() {
		if (CurrentLevel < MAX_LEVEL)
		{
			LoadScene("Level" + (CurrentLevel + 1));
		}
		else {
			LoadScene("StageSelectionW1");
		}
	}

	public void ResetScene() {
		LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadTitleScreen() {
		LoadScene("TitleScreen");
	}

	public void LoadWorld1() {
		LoadScene("StageSelectionW1");
	}

	public void LoadCredits() {
		LoadScene("Credits");
	}

	#endregion

	public int UnlockedLevel() {
		return SaveManager.Instance.GetUnlockedLevel();
	}

	public void ClearProgress() {
		SaveManager.Instance.ClearSave();
	}

	public void StageCleared(int p_score) {
		if (CurrentLevel == SaveManager.Instance.GetUnlockedLevel()) 
		{
			SaveManager.Instance.SetUnlockedLevel(CurrentLevel + 1);
		}
		if (p_score > SaveManager.Instance.GetLevelScore(CurrentLevel)) 
		{
			SaveManager.Instance.SetLevelScore(CurrentLevel, p_score);
		}
		if (CurrentLevel == MAX_LEVEL) 
		{
			if (!SaveManager.Instance.GetShowedGameConclusion()) 
			{
				redirectToCredits = true;
			}
		}
	}
}
