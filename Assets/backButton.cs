using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton : MonoBehaviour
{
    public void onClick() {
        transform.parent.gameObject.SetActive(false);
    }
}
