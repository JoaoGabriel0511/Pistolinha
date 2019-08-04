using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopShooting : MonoBehaviour
{
    public void StopShoot() {
        GetComponent<Animator>().SetBool("isShooting", false);
    }
}
