using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagePanel : MonoBehaviour
{
    public int level;
    
    public void SetPanel() {
        int starsScore = PlayerPrefs.GetInt("Level" + level + "Stars", 0);
        if (starsScore > 0) {
            gameObject.transform.Find("Star1").gameObject.SetActive(true);
        } else {
            gameObject.transform.Find("Star1").gameObject.SetActive(false);
        }
        if (starsScore > 1) {
            gameObject.transform.Find("Star2").gameObject.SetActive(true);
        } else {
            gameObject.transform.Find("Star2").gameObject.SetActive(false);
        }
        if (starsScore > 2) {
            gameObject.transform.Find("Star3").gameObject.SetActive(true);
        } else {
            gameObject.transform.Find("Star3").gameObject.SetActive(false);
        }
    }
}
