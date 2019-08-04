using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAnimationTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<IColorful>() != null) {
            Wall wall = other.GetComponent<Wall>();
            if (wall != null) {
                switch (wall.GetColor()) {
                    case Constants.Type.GREEN:
                        GetComponent<Animator>().SetBool("explodeWall", true);
                        break;
                    case Constants.Type.RED:
                        GetComponent<Animator>().SetBool("hitingWall", true);
                        break;
                    case Constants.Type.BLUE:
                        break;
                }
            }
        }
    }
}
