using UnityEngine;

public class Cannon : MonoBehaviour {

	[SerializeField] GameObject ballRedPrefab;
	[SerializeField] GameObject ballGreenPrefab;
	[SerializeField] GameObject ballBluePrefab;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] BallCollisionBehaviour[] ballBehaviours;

	Constants.Type selectedColor = Constants.Type.RED;
	SpriteRenderer _spriteRenderer;

	void Awake() {
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}
		_spriteRenderer.color = Color.red;
	}

	void Update() {
		if (Input.GetButtonDown("Fire")) {
			Shoot();
		}
		if (Input.GetButtonDown("NextBall")) {
			SwitchToNextBall();
		}
		if (Input.GetButtonDown("PreviousBall")) {
			SwitchToPreviousBall();
		}
	}

	private void SwitchToPreviousBall() {
		switch (selectedColor) {
			case Constants.Type.RED:
				selectedColor = Constants.Type.GREEN;
				_spriteRenderer.color = Color.green;
				break;
			case Constants.Type.BLUE:
				selectedColor = Constants.Type.RED;
				_spriteRenderer.color = Color.red;
				break;
			case Constants.Type.GREEN:
				selectedColor = Constants.Type.BLUE;
				_spriteRenderer.color = Color.blue;
				break;
			default:
				break;
		}
	}

	private void SwitchToNextBall() {
		switch (selectedColor) {
			case Constants.Type.RED:
				selectedColor = Constants.Type.BLUE;
				_spriteRenderer.color = Color.blue;
				break;
			case Constants.Type.BLUE:
				selectedColor = Constants.Type.GREEN;
				_spriteRenderer.color = Color.green;
				break;
			case Constants.Type.GREEN:
				selectedColor = Constants.Type.RED;
				_spriteRenderer.color = Color.red;
				break;
			default:
				break;
		}
	}

	private void Shoot() {
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
	}
}
