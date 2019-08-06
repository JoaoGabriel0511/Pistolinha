using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Two instances of GameManager! Destroying gameObject");
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        BGMusic = FMODUnity.RuntimeManager.CreateInstance(BGEvent);
        BGMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        BGMusic.start();
        */
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "GameGUI") SceneManager.SetActiveScene(scene);

        //if (scene.name.Contains("Level")) SceneManager.LoadScene("GameGUI");
    }

    public void StartGame()
    {
        if (LastPlayed() == 0)
        {
            StageCleared(0);
            LoadScene("Level1");
        }
        else
        {
            LoadScene("StageSelection");
        }
    }

    public void UnloadActiveScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0) return;

        if (scene.name.Contains("Level"))
        {
            SceneManager.UnloadSceneAsync("GameGUI");
        }
        SceneManager.UnloadSceneAsync(scene.buildIndex);
    }

    public void LoadScene(string scene)
    {
        //SceneManager.LoadScene(scene, LoadSceneMode.Single);
        UnloadActiveScene();
        if (scene.Contains("Level"))
        {
            int level;
            int.TryParse(scene.Remove(0, "Level".Length), out level);
            if (level > PlayerPrefs.GetInt("LastPlayed"))
            {
                PlayerPrefs.SetInt("LastPlayed", level);
            }
            //StartCoroutine(LoadSceneAsync(scene));
            SceneManager.LoadScene("GameGUI", LoadSceneMode.Additive);
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
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
