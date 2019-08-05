﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [FMODUnity.EventRef]
    public string BGEvent;
    FMOD.Studio.EventInstance BGMusic;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Two instances of GameManager! Destroying gameObject");
            Destroy(gameObject);
        }
        Screen.SetResolution(576, 1024, true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        BGMusic = FMODUnity.RuntimeManager.CreateInstance(BGEvent);
        BGMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BGMusic.start();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("scene.name: " + scene.name);
        if (scene.name.Contains("Level"))
        {
            Debug.Log("has level");
            int level;
            int.TryParse(scene.name.Remove(0, "Level".Length), out level);
            if (level != 0)
            {
                Debug.Log("level not zero");
                SceneManager.LoadScene("GameGUI", LoadSceneMode.Additive);
            }
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        /*
        Debug.Log("Try load");
        if (scene.Contains("Level"))
        {
            Debug.Log("Its a level");
            int level;
            int.TryParse(scene.Remove(0, "Level".Length), out level);
            if (level > PlayerPrefs.GetInt("LastPlayed"))
            {
                Debug.Log("its new");
                PlayerPrefs.SetInt("LastPlayed", level);
            }

            if (level != 0)
                StartCoroutine(LoadSceneAsync(scene));
            else
                SceneManager.LoadScene(scene, LoadSceneMode.Single);

        }*/
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            yield return null;
        }
        SceneManager.LoadScene("GameGUI", LoadSceneMode.Additive);
    }

    public int LastPlayed()
    {
        return PlayerPrefs.GetInt("LastPlayed", 0);
    }

    public void ClearProgress()
    {
        PlayerPrefs.SetInt("LastPlayed", 0);
    }

    public void ResetScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StageCleared()
    {
        int stage = int.Parse(SceneManager.GetActiveScene().name.Remove(0, "Level".Length));
        if(stage == PlayerPrefs.GetInt("LastPlayed"))
        {
            PlayerPrefs.SetInt("LastPlayed", stage + 1);
        }
    }

    public void StageCleared(int zero)
    {
        PlayerPrefs.SetInt("LastPlayed", 1);
    }

    public void LoadNextLevel()
    {
        int currentLevel = int.Parse(SceneManager.GetActiveScene().name.Remove(0, "Level".Length));
        if(currentLevel < 10)
            LoadScene("Level"+(currentLevel+1));
        else
        {
            LoadScene("LevelSelection");
        }
    }

}
