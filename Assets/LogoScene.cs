using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour
{
    [SerializeField] float secondsToStart = 3.0f;
    private IEnumerator Start() {
        yield return new WaitForSeconds(secondsToStart);
        SceneManager.LoadScene("ManagerScene");
    }
}
