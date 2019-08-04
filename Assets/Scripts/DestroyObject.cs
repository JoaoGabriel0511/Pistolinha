using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    public void Destroy() {
        GetComponent<Animator>().SetBool("explodeWall", true);
        Destroy(transform.parent.gameObject);
    }
}
