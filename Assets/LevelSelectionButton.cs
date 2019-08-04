using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelLabel;
    [SerializeField] Image lockIcon;

    void Start()
    {
        if(GameManager.Instance.LastPlayed() >= int.Parse(levelLabel.text))
        {
            lockIcon.gameObject.SetActive(false);
            levelLabel.gameObject.SetActive(true);
        }
    }

    public void OnClick()
    {
        Debug.Log("Clicked");
        int level;
        int.TryParse(levelLabel.text, out level);

        
        if (level <= GameManager.Instance.LastPlayed())
        {
            GameManager.Instance.LoadScene("Level"+level);
        }
    }
}
