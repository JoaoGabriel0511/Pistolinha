using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(LoadOperation());
    }

    IEnumerator LoadOperation() {
        return GameManager.Instance.LoadSceneAsync("StageSelection");
    }


}
