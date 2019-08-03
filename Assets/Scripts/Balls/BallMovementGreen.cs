using UnityEngine;

public class BallMovementGreen : BallMovement {
	public override void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<IColorful>() != null) {
			Wall wall = other.GetComponent<Wall>();
			if (wall != null) {
				switch (wall.GetColor()) {
					case Constants.Type.GREEN:
						Destroy(gameObject);
						break;
					case Constants.Type.RED:
						ColisionWithWall(wall.Angle);
						break;
					case Constants.Type.BLUE:
						break;
				}
			}
		}
	}
}
