using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStageSelectionPanel : MonoBehaviour
{
    [SerializeField] List<UIScoreStar> scoreStars = new List<UIScoreStar>();

    int level;
    
    public void OpenPanel(int p_level) 
    {
        level = p_level;
        gameObject.SetActive(true);
        SetScoreStars(SaveManager.Instance.GetLevelScore(p_level));
    }

    public void ClosePanel() 
    {
        gameObject.SetActive(false);
    }

    public void PlayLevel() 
    {
        GameManager.Instance.LoadScene("Level"+level);
    }

    void Awake() 
    {
        ClosePanel();
    }

    void SetScoreStars(int p_score) 
    {
        for (int i = 0; i < scoreStars.Count; i++)
        {
            scoreStars[i].SetStar(p_score > i);
        }
    }
}
