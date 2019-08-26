using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallMovement : MonoBehaviour {

	[SerializeField] AudioClip bounce;
	[SerializeField] AudioClip pass;
	[SerializeField] AudioClip die;
	AudioSource sound;


	enum Sound {
		BOUNCE,
		DEATH,
		PHASE,
		VIEW_SOUND_ORDER
	}
	//[SerializeField] Sound sound = Sound.VIEW_SOUND_ORDER;

	//  Internal references
	Rigidbody2D _rb2D;
	BallAttribute _ballAttr;
	//Animator _animator;

	//float centerDistance = Mathf.Infinity;
	public Constants.Type Type { get { return _ballAttr.GetColor(); } }

	protected void Awake() {
		_rb2D = GetComponent<Rigidbody2D>();
		_ballAttr = GetComponent<BallAttribute>();
		//_animator = GetComponentInChildren<Animator>();
		//sound = Sound.DEATH;

		sound = GetComponent<AudioSource>();
		if (!sound) {
			Debug.Log("No audio source component!");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		_ballAttr.collisionBehaviour.ResolveCollision(other.gameObject, this);
	}

	protected void ColisionWithWall(float wallAngle) {
		// Assumes that walls will be rotated with 0, 90, 45 and -45 degrees
		if (Mathf.Approximately(Mathf.Abs(Mathf.Abs(wallAngle) - Mathf.Abs(transform.rotation.eulerAngles.z % 180)), 90)) {
			if (transform.rotation.eulerAngles.z < 0) {
				transform.eulerAngles = Vector3.forward * ((180 + transform.eulerAngles.z) % 360);
			}
			else {
				transform.eulerAngles = Vector3.forward * ((-180 + transform.eulerAngles.z) % 360);
			}
		}
		else {
			if (Mathf.Approximately((int)transform.rotation.eulerAngles.z % 180, 0)) {
				transform.eulerAngles = Vector3.forward * ((wallAngle * 2 + transform.eulerAngles.z) % 360);
			}
			else {
				transform.eulerAngles = Vector3.forward * ((wallAngle * -2 + transform.eulerAngles.z) % 360);
			}
		}

		// Redirect the velocity
		_rb2D.velocity = transform.right * _rb2D.velocity.magnitude;
	}

	protected IEnumerator MakeColision(Wall wall) {
		if (_ballAttr.IsColiding()) {
			yield break;
		}
		_ballAttr.SetColiding(true);

		float dt = Vector3.Distance(wall.transform.position, transform.position) / _ballAttr.GetSpeed();
		yield return new WaitForSeconds(dt);
		transform.position = wall.transform.position;
		ColisionWithWall(wall.Angle);
		sound.clip = bounce;
		sound.Play();

		//  change for audioSource
		//_audioEmitter.ChangeSound((int)Sound.BOUNCE);
		//_audioEmitter.PlaySound();

		yield return new WaitForSeconds(dt / 2);
		_ballAttr.SetColiding(false);
	}

	protected IEnumerator MakeDeath(Wall wall) {
		if (_ballAttr.IsColiding()) {
			yield break;
		}
		_ballAttr.SetColiding(true);

		float dt = Vector3.Distance(wall.transform.position, transform.position) / _ballAttr.GetSpeed();
		sound.clip = die;
		sound.Play();
		yield return new WaitForSeconds(dt);
		transform.position = wall.transform.position;
		_ballAttr.SetColiding(false);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		//  change for audioSource
		//_audioEmitter.ChangeSound((int)Sound.DEATH);
		//_audioEmitter.PlaySound();
		//_animator.SetBool("explodeWall", true);

		Destroy(transform.gameObject);
		yield break;
	}

	protected IEnumerator MakePhase() {
		//  change for audioSource
		//_audioEmitter.ChangeSound((int)Sound.PHASE);
		sound.clip = pass;
		sound.Play();
		yield break;
	}

	public void SetRotation(Quaternion rotation) {
		transform.eulerAngles = rotation.eulerAngles;
		_rb2D.velocity = transform.right * _ballAttr.GetSpeed();
	}
}
