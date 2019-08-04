using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelLabel;
    public void OnClick()
    {
        Debug.Log("Clicked");
        int level;
        int.TryParse(levelLabel.text, out level);

        
        //if (level <= GameManager.Instance.LastPlayed())
        //{
            GameManager.Instance.LoadScene("Level"+level);
        //}
    }
}
