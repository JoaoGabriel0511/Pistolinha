using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ColorMunition : MonoBehaviour
{
    [SerializeField] Constants.Type type;
    [SerializeField] Cannon cannon;

    public void OnClick()
    {
        Debug.Log("Called");
        cannon.ChangeColor(type);
    }
}
