using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public Cannon cannon;
    public GameObject panel;
    public GameObject closedButton;

    public void SwitchToGreen() {
        cannon.SwitchToGreen(); 
    }

    public void SwitchToRed() {
        cannon.SwitchToRed(); 
    }

    public void SwitchToBlue() {
        cannon.SwitchToBlue();
    }

    public void HideCollorSelector() {
        panel.SetActive(false);
        closedButton.SetActive(true);
    }

    public void ShowCollorSelector() {
        panel.SetActive(true);
        closedButton.SetActive(false);
    }
}
