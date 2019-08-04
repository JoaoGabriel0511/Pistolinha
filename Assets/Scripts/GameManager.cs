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
            DontDestroyOnLoad(gameObject);
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (scene.Contains("Level"))
        {
            int level;
            int.TryParse(scene.Remove(0, "Level".Length), out level);
            if (level > PlayerPrefs.GetInt("LastPlayed"))
            {
                PlayerPrefs.SetInt("LastPlayed", level);
            }

            if (level != 0)
                StartCoroutine(LoadSceneAsync(scene));
            else
                SceneManager.LoadScene(scene, LoadSceneMode.Single);

        }
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

}
