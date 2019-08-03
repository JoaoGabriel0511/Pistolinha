using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IColorful {
	[SerializeField] Constants.Type _color;
	SpriteRenderer _spriteRenderer;

	void Awake() {
		_spriteRenderer = GetComponent<SpriteRenderer>();
		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}
		UpdateColor();
	}

	public Constants.Type GetColor() {
		return _color;
	}

	void UpdateColor() {
		switch (_color) {
			case Constants.Type.RED:
				_spriteRenderer.color = Color.red;
				break;
			case Constants.Type.GREEN:
				_spriteRenderer.color = Color.green;
				break;
			case Constants.Type.BLUE:
				_spriteRenderer.color = Color.blue;
				break;
		}
	}

	void OnTriggerEnter2D(Collision2D other) {
		if (other.gameObject.GetComponent<BallAttribute>()) {
			BallAttribute ball = other.gameObject.GetComponent<BallAttribute>();
			if (ball.GetColor() != _color) {
				_color = ball.GetColor();
				UpdateColor();
			}
		}
	}
}
