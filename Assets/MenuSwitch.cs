using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour
{
    [SerializeField] GameObject targetMenu;

    public void switchToTargetMenu() {
        targetMenu.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
