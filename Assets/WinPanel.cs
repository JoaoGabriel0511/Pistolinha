using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Goal>().StageCleared.AddListener(OnStageCleared);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStageCleared()
    {
        gameObject.SetActive(true);
    }

    void OnFinishedOpening()
    {

    }

    public void LoadNextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }
}
