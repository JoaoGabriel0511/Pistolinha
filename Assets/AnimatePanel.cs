using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePanel : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        animator.SetBool("Out", true);
    }

    public void OnOpenFinished()
    {

    }

    public void OnCloseFinished()
    {
        gameObject.SetActive(false);
    }


}
