using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    //  External
    [SerializeField] BallCollisionBehaviour ballCollisionBehaviour;
    
    //  Internal references
	protected Rigidbody2D rb2D;
	protected BallAttribute _ballAtrib;
	float centerDistance = Mathf.Infinity;

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

    public void OnTriggerExit2D(Collider2D collision) {
        GetComponentInChildren<Animator>().SetBool("hitingWall", false);
    }

    public void SetBehaviour(BallCollisionBehaviour ballCollisionBehaviour)
    {
        this.ballCollisionBehaviour = ballCollisionBehaviour;
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

	protected IEnumerator MakeColision(Wall wall) {
		if (_ballAtrib.IsColiding()) {
			yield break;
		}
		_ballAtrib.SetColiding(true);

		float dt = Vector3.Distance(wall.transform.position, transform.position) / _ballAtrib.GetSpeed();
		yield return new WaitForSeconds(dt);
		transform.position = wall.transform.position;
		ColisionWithWall(wall.Angle);

		yield return new WaitForSeconds(2 * dt);
		_ballAtrib.SetColiding(false);
	}

	protected IEnumerator MakeDeath(Wall wall) {
		if (_ballAtrib.IsColiding()) {
			yield break;
		}
		_ballAtrib.SetColiding(true);

		float dt = Vector3.Distance(wall.transform.position, transform.position) / _ballAtrib.GetSpeed();
		yield return new WaitForSeconds(dt);
		transform.position = wall.transform.position;
		_ballAtrib.SetColiding(false);
		Destroy(gameObject);
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	public void SetRotation(Quaternion rotation) {
		transform.rotation = rotation;
		rb2D.velocity = _ballAtrib.GetSpeed() * Vector3.right;
	}
}
