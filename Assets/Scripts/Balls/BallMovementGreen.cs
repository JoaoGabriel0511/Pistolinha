using UnityEngine;

public class BallMovementGreen : BallMovement {
	public override void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<IColorful>() != null) {
			Wall wall = other.GetComponent<Wall>();
			if (wall != null) {
				switch (wall.GetColor()) {
					case Constants.Type.GREEN:
                        GetComponentInChildren<Animator>().SetBool("explodeWall", true);
                        StartCoroutine("MakeDeath", wall);
						break;
					case Constants.Type.RED:
						StartCoroutine("MakeColision", wall);
                        GetComponentInChildren<Animator>().SetBool("hitingWall", true);
                        break;
					case Constants.Type.BLUE:
						break;
				}
			}
		}
	}
}
