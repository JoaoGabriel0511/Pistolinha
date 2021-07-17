using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] int levelNro = 0;
    [SerializeField] Sprite lockedSprite = null;
    [SerializeField] Sprite unlockedSprite = null;
    [SerializeField] UIStageSelectionPanel stageSelectionPanel = null;
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
            stageSelectionPanel.OpenPanel(levelNro);
        }
    }
}
