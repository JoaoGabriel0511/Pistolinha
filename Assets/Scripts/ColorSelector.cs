using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class ColorSelector : MonoBehaviour
{
    public Cannon cannon;
    Animator animator;
    public GameObject panel;

    public void SwitchToGreen() {
        cannon.SwitchToGreen(); 
    }

    public void SwitchToRed() {
        cannon.SwitchToRed(); 
    }

    public void SwitchToBlue() {
        cannon.SwitchToBlue();
    }

    public void ToggleCollorSelector() {
        animator = panel.GetComponent<Animator>();
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        if (animator.GetBool("isOpen")) {
            animator.SetBool("isOpen", false);
            Debug.Log(animator.GetBool("isOpen"));
            text.text = ">>>>";
        } else {
            animator.SetBool("isOpen", true);
            Debug.Log(animator.GetBool("isOpen"));
            text.text = "<<<<";
        }    
    }
}
