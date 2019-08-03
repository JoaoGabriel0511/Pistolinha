using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    public void OnClick()
    {
        if(GameManager.Instance.LastPlayed() == -1)
        {
            GameManager.Instance.LoadScene("Level1");
        }
        else
        {
            GameManager.Instance.LoadScene("LevelSelection");
        }
    }

}
