using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ColorMunition : MonoBehaviour
{
    [SerializeField] Constants.Type type;
    [SerializeField] Cannon cannon;

    void Start()
    {
        cannon = FindObjectOfType<Cannon>();
    }

    public void OnClick()
    {
        Debug.Log("Called");
        cannon.ChangeColor(type);
    }
}
