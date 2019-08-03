using UnityEngine;
using UnityEngine.Events;

public class BallMovement : MonoBehaviour {
	//  Internal references
	protected Rigidbody2D rb2D;
	protected BallAttribute _ballAtrib;

	protected void Awake() {
		rb2D = GetComponent<Rigidbody2D>();
		_ballAtrib = GetComponent<BallAttribute>();
	}

	public virtual void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<IColorful>() != null) {
			Wall wall = other.GetComponent<Wall>();
			if (wall != null) {
				if (wall.GetColor() == _ballAtrib.GetColor()) {
					ColisionWithWall(wall.Angle);
				}
				else {
					Destroy(gameObject);
				}
			}
		}
	}

	protected void ColisionWithWall(float wallAngle) {
		// Assumes that walls will be rotated with 0, 90, 45 and -45 degrees
		if (Mathf.Approximately(Mathf.Abs(wallAngle - transform.rotation.eulerAngles.z), 90)) {
			if (transform.rotation.eulerAngles.z < 0) {
				transform.eulerAngles = Vector3.forward * ((180 + transform.eulerAngles.z) % 360);
			}
			else {
				transform.eulerAngles = Vector3.forward * ((-180 + transform.eulerAngles.z) % 360);
			}
		}
		else {
			if (Mathf.Approximately(transform.rotation.eulerAngles.z % 180, 0)) {
				transform.eulerAngles = Vector3.forward * ((wallAngle * 2 + transform.eulerAngles.z) % 360);
			}
			else {
				transform.eulerAngles = Vector3.forward * ((wallAngle * -2 + transform.eulerAngles.z) % 360);
			}
		}

		// Redirect the velocity
		rb2D.velocity = transform.right * rb2D.velocity.magnitude;
	}

	public void SetRotation(Quaternion rotation) {
		transform.rotation = rotation;
		rb2D.velocity = _ballAtrib.GetSpeed() * Vector3.right;
	}
}
