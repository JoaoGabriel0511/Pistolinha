using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	[SerializeField] GameObject redBallPrefab;
	[SerializeField] GameObject blueBallPrefab;
	[SerializeField] GameObject greenBallPrefab;

	[SerializeField] bool _redEnable = true;
	[SerializeField] bool _blueEnable = true;
	[SerializeField] bool _greenEnable = true;

	[SerializeField] Constants.Type selectedColor = Constants.Type.NONE;
	SpriteRenderer _spriteRenderer;
	BoxCollider2D _collider2D;
	//Animator _animator;

	void Awake() {
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		_collider2D = GetComponentInChildren<BoxCollider2D>();
		//_animator = GetComponentInChildren<Animator>();

		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}

		if (!_collider2D) {
			Debug.Log("No Collider2D found.");
		}

		if (!_redEnable && !_blueEnable && !_greenEnable) {
			Debug.Log("No color enabled in the cannon!");
		}
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Input.mousePosition;
			Bounds bounds = _collider2D.bounds;
			Vector2 size = _collider2D.size;
			if (new Rect(bounds.min.x, bounds.min.y, size.x, size.y).Contains(Camera.main.ScreenToWorldPoint(mousePos))) {
				Shoot();
			}
		}
	}

	public void ChangeColor(Constants.Type type) {
		switch (type) {
			case Constants.Type.BLUE:
				SwitchToBlue();
				break;
			case Constants.Type.RED:
				SwitchToRed();
				break;
			case Constants.Type.GREEN:
				SwitchToGreen();
				break;
			default:
				break;
		}
	}
	void SwitchToGreen() => selectedColor = Constants.Type.GREEN;
	void SwitchToBlue() => selectedColor = Constants.Type.BLUE;
	void SwitchToRed() => selectedColor = Constants.Type.RED;
	/*
		void SwitchToPreviousBall() {
			switch (selectedColor) {
				case Constants.Type.RED:
					selectedColor = Constants.Type.GREEN;
					break;
				case Constants.Type.BLUE:
					selectedColor = Constants.Type.RED;
					break;
				case Constants.Type.GREEN:
					selectedColor = Constants.Type.BLUE;
					break;
				default:
					break;
			}
		}

		void SwitchToNextBall() {
			switch (selectedColor) {
				case Constants.Type.RED:
					selectedColor = Constants.Type.BLUE;
					break;
				case Constants.Type.BLUE:
					selectedColor = Constants.Type.GREEN;
					break;
				case Constants.Type.GREEN:
					selectedColor = Constants.Type.RED;
					break;
				default:
					break;
			}
		}
	*/
	public void Shoot() {
		StartCoroutine("MakeShot");

		if (GetComponent<LevelManager>() != null && selectedColor != Constants.Type.NONE) {
			GetComponent<LevelManager>().CountShoot();
		}
	}

	IEnumerator MakeShot() {
		//yield return new WaitForSeconds(0.175f);

		BallMovement ball;
		Debug.Log(selectedColor);
		switch (selectedColor) {
			case Constants.Type.RED:
				ball = Instantiate(redBallPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.BLUE:
				ball = Instantiate(blueBallPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.GREEN:
				ball = Instantiate(greenBallPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			default:
				ball = null;
				break;
		}

		if (ball) {
			ball.gameObject.SetActive(true);
			ball.SetRotation(transform.rotation);
		}

		yield break;
	}
}
