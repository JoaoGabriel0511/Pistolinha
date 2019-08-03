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
        SceneManager.sceneLoaded += OnSceneLoaded;
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
        if (scene.name.Contains("Level"))
        {    
            int level;
            int.TryParse(scene.name.Remove(0, "Level".Length), out level);
            if (level != 0)
            {
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
            if(level > PlayerPrefs.GetInt("LastPlayed"))
                PlayerPrefs.SetInt("LastPlayed", level);
            
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    public int LastPlayed()
    {
        return PlayerPrefs.GetInt("LastPlayed", -1);
    }

    public void ClearProgress()
    {
        PlayerPrefs.SetInt("LastPlayed", -1);
    }

}
