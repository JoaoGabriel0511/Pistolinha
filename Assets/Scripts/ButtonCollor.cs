using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollor : MonoBehaviour
{
    [SerializeField] Constants.Type collor;

    public Constants.Type GetCollor() {
        return collor;
    }
}
