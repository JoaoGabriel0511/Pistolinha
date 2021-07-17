using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLevelButton : MonoBehaviour
{
    public void onClick() {
        int level = GetComponentInParent<stagePanel>().level;
        if (level <= GameManager.Instance.UnlockedLevel())
        {
            GameManager.Instance.LoadScene("Level"+level);
        }
    }
}
