using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	//  Internal references
	protected Rigidbody2D rb2D;
	protected BallAttribute _ballAttr;
	AudioSource _audioSource;
	AudioClip _audioClip;
	float centerDistance = Mathf.Infinity;

	[FMODUnity.EventRef]
	public string bounceEventSFX;
	FMOD.Studio.EventInstance _bounceSFX;

	[FMODUnity.EventRef]
	public string deathEventSFX;
	FMOD.Studio.EventInstance _deathSFX;

	[FMODUnity.EventRef]
	public string phaseEventSFX;
	FMOD.Studio.EventInstance _phaseSFX;

    protected void Awake() {
		rb2D = GetComponent<Rigidbody2D>();
		_ballAttr = GetComponent<BallAttribute>();
		_audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other) {
        _ballAttr.collisionBehaviour.ResolveCollision(other.gameObject, this);
	}

	public void OnTriggerExit2D(Collider2D collision) {
		GetComponentInChildren<Animator>().SetBool("hitingWall", false);
	}

	protected void ColisionWithWall(float wallAngle) {
		// Assumes that walls will be rotated with 0, 90, 45 and -45 degrees
		Debug.Log((int)transform.rotation.eulerAngles.z);

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
		rb2D.velocity = transform.right * rb2D.velocity.magnitude;
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

		_bounceSFX = FMODUnity.RuntimeManager.CreateInstance(bounceEventSFX);
		_bounceSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
		_bounceSFX.start();

		yield return new WaitForSeconds(dt / 2);
		_ballAttr.SetColiding(false);
	}

	protected IEnumerator MakeDeath(Wall wall) {
		if (_ballAttr.IsColiding()) {
			yield break;
		}
		_ballAttr.SetColiding(true);

		float dt = Vector3.Distance(wall.transform.position, transform.position) / _ballAttr.GetSpeed();
		yield return new WaitForSeconds(dt);
		transform.position = wall.transform.position;
		_ballAttr.SetColiding(false);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		_deathSFX = FMODUnity.RuntimeManager.CreateInstance(deathEventSFX);
		_deathSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
		_deathSFX.start();

		// Destroy(gameObject);
	}

	protected IEnumerator MakePhase() {
		_phaseSFX = FMODUnity.RuntimeManager.CreateInstance(phaseEventSFX);
		_phaseSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
		_phaseSFX.start();
		yield break;
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	public void SetRotation(Quaternion rotation) {
		transform.eulerAngles = rotation.eulerAngles;
		rb2D.velocity = transform.right * _ballAttr.GetSpeed();
	}
}
