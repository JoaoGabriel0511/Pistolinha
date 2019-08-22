using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update
    private int shootCount;
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
        shootCount = FindObjectOfType<LevelManager>().GetShootCount();
        if(shootCount < FindObjectOfType<LevelManager>().GetShootsFor1Star()) {
            gameObject.transform.FindChild("Star1").gameObject.SetActive(true);
        }
        if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor2Stars()) {
            gameObject.transform.FindChild("Star2").gameObject.SetActive(true);
        }
        if (shootCount < FindObjectOfType<LevelManager>().GetShootsFor3Stars()) {
            gameObject.transform.FindChild("Star3").gameObject.SetActive(true);
        }
        TextMeshProUGUI textMeshPro = gameObject.transform.FindChild("TotalShoots").gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(textMeshPro);
        textMeshPro.text = "Shoots: " + shootCount;
        gameObject.SetActive(true);
    }

    void OnFinishedOpening()
    {

    }

    public void LoadMap() {
        GameManager.Instance.LoadScene("WorldSelect");
    }

    public void LoadSameLevel() {
        GameManager.Instance.LoadSameLevel();
    }

    public void LoadNextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }
}
