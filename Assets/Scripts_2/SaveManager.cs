using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    const string KEY_UNLOCKED_LEVEL = "UnlockedLevel";
    const string KEY_LAST_PLAYED_LEVEL = "LastPlayedLevel";
    const string KEY_LEVEL_SCORE = "LevelScore_";
    
    public static SaveManager Instance;

    void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicated singleton!");
        }
    }

    #region Public Methods

    public void SetUnlockedLevel(int p_level) 
    {
        PlayerPrefs.SetInt(KEY_UNLOCKED_LEVEL, p_level);
        PlayerPrefs.Save();
    }

    public int GetUnlockedLevel()
    {
        return PlayerPrefs.GetInt(KEY_UNLOCKED_LEVEL, 1);
    }

    public void SetLevelScore(int p_level, int p_score) 
    {
        PlayerPrefs.SetInt(KEY_LEVEL_SCORE + p_level.ToString(), p_score);
        PlayerPrefs.Save();
    }

    public int GetLevelScore(int p_level) 
    {
        return PlayerPrefs.GetInt(KEY_LEVEL_SCORE + p_level.ToString(), 0);
    }

    public void ClearSave() 
    {
        PlayerPrefs.DeleteAll();
    }

    #endregion
}
