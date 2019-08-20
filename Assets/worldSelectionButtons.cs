using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class worldSelectionButtons : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelLabel;
    [SerializeField] Image lockIcon;
    int index = -1;

    void Start() {
        for (int i = 0; i < transform.parent.childCount; i++) {
            if (gameObject == transform.parent.GetChild(i).gameObject) {
                index = i + 1;
                break;
            }
        }
        levelLabel.text = index.ToString();
        //if (GameManager.Instance.LastPlayed() >= int.Parse(levelLabel.text)) {
            lockIcon.gameObject.SetActive(false);
            levelLabel.gameObject.SetActive(true);
        //}
    }

    public void OnClick() {
        int world;
        int.TryParse(levelLabel.text, out world);
        GameManager.Instance.LoadScene("StageSelectionW" + world);
    }
}
