﻿using UnityEngine;

public class BallMovementRed : BallMovement {
	public override void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<IColorful>() != null) {
			Wall wall = other.GetComponent<Wall>();
			if (wall != null) {
				switch (wall.GetColor()) {
					case Constants.Type.RED:
						StartCoroutine("MakeColision", wall);
						break;
					case Constants.Type.BLUE:
						break;
					case Constants.Type.GREEN:
						StartCoroutine("MakeDeath", wall);
						break;
				}
			}
		}
	}
}
