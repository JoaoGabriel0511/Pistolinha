using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class ColorMunitionEvent : UnityEvent<Constants.Type> { }
public class ColorMunition : MonoBehaviour
{
    [SerializeField] Constants.Type type;
    [SerializeField] Cannon cannon;

    public ColorMunitionEvent clickedEvent = new ColorMunitionEvent();

    void Start()
    {
        cannon = FindObjectOfType<Cannon>();
    }

    public void OnClick()
    {
        clickedEvent?.Invoke(type);
    }
}
