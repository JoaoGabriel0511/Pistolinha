using UnityEngine;

public class BallMovementBlue : BallMovement {
	public override void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<IColorful>() != null) {
			Wall wall = other.GetComponent<Wall>();
			if (wall != null) {
				switch (wall.GetColor()) {
					case Constants.Type.BLUE:
						break;
					case Constants.Type.GREEN:
						StartCoroutine("MakeColision", wall);
                        GetComponentInChildren<Animator>().SetBool("hitingWall", true);
						break;
					case Constants.Type.RED:
                        GetComponentInChildren<Animator>().SetBool("explodeWall", true);
                        StartCoroutine("MakeDeath", wall);
                        break;
				}
			}
		}
	}
}
