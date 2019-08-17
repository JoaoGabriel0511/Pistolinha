using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadMap() {
        GameManager.Instance.LoadScene("StageSelection");
    }

    public void LoadSameLevel() {
        GameManager.Instance.LoadSameLevel();
    }

    public void LoadNextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }
}
