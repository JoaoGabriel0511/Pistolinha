using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCredits : MonoBehaviour
{
    public void OnClick() {
        GameManager.Instance.LoadScene("Credits");
    }
}
