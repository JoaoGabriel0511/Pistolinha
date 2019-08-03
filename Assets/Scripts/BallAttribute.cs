using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttribute : MonoBehaviour, IColorful
{
    Constants.Type ballType;

    public Constants.Type GetColor()
    {
        return ballType;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        IColorful iColorful = collision2D.gameObject.GetComponent<IColorful>();
        Debug.Log("Colidiu");
    }
}
