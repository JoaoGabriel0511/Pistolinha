using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTitle : MonoBehaviour
{
   public void OnClick() {
        GameManager.Instance.LoadScene("TitleScreen");
   }
}
