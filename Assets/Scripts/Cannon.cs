using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour {

	[SerializeField] GameObject ballRedPrefab;
	[SerializeField] GameObject ballGreenPrefab;
	[SerializeField] GameObject ballBluePrefab;
	[SerializeField] GameObject ballPrefab;
	[SerializeField] BallCollisionBehaviour[] ballBehaviours;

	Constants.Type selectedColor = Constants.Type.RED;
	SpriteRenderer _spriteRenderer;

	[FMODUnity.EventRef]
	public string ShotEvent;
	FMOD.Studio.EventInstance Shot;

	void Awake() {
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}
		_spriteRenderer.color = Color.red;
	}

    private void OnCollisionEnter2D(Collision2D collision) {

    }

    void Update() {
		if (Input.GetButtonDown("Fire")) {
			Shoot();
		}
	}

	public void SwitchToRed() {
        selectedColor = Constants.Type.RED;
        _spriteRenderer.color = Color.red;
    }

	public void SwitchToGreen() {
        selectedColor = Constants.Type.GREEN;
        _spriteRenderer.color = Color.green;
	}

    public void SwitchToBlue() {
        selectedColor = Constants.Type.BLUE;
        _spriteRenderer.color = Color.blue;
    }

	private void Shoot() {
		Shot = FMODUnity.RuntimeManager.CreateInstance(ShotEvent);
		Shot.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
		Shot.start();

		StartCoroutine("MakeShootSFX");
	}

	IEnumerator MakeShootSFX() {
		yield return new WaitForSeconds(0.175f);

		BallMovement ball;
		switch (selectedColor) {
			case Constants.Type.RED:
				ball = Instantiate(ballRedPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.BLUE:
				ball = Instantiate(ballBluePrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.GREEN:
				ball = Instantiate(ballGreenPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			default:
				ball = null;
				break;
		}
		if (ball) {
			ball.SetRotation(transform.rotation);
		}

		yield break;
	}
}
