using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] int levelNro;
    [SerializeField] Sprite lockedSprite;
    [SerializeField] Sprite unlockedSprite;
    [SerializeField] GameObject stageSelectPanel;
    int index = -1;
    bool locked = true;

    void Start()
    {
        if(GameManager.Instance.UnlockedLevel() >= levelNro)
        {
            GetComponent<Image>().sprite = unlockedSprite;
            locked = false;
        } else {
            GetComponent<Image>().sprite = lockedSprite;
            locked = true;
        }
    }

    public void OnClick()
    {
        if (!locked) {
            stageSelectPanel.SetActive(true);
            stageSelectPanel.GetComponent<stagePanel>().level = levelNro;
        }
    }
}
