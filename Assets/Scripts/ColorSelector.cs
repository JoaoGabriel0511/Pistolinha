using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public Cannon cannon;
    Animator animator;
    public GameObject panel;

    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void ToggleCollorSelector() {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
}
