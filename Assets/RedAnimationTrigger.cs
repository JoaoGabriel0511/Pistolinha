using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAnimationTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<IColorful>() != null) {
            Wall wall = other.GetComponent<Wall>();
            if (wall != null) {
                switch (wall.GetColor()) {
                    case Constants.Type.RED:
                        GetComponentInChildren<Animator>().SetBool("hitingWall", true);
                        break;
                    case Constants.Type.BLUE:
                        break;
                    case Constants.Type.GREEN:
                        GetComponentInChildren<Animator>().SetBool("explodeWall", true);
                        break;
                }
            }
        }
    }
}
