using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public void OnClick(string level)
    {
        GameManager.Instance.LoadScene(level);
    }
}
