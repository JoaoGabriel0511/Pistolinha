using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IColorful {
	[SerializeField] Constants.Type _color;
	SpriteRenderer _spriteRenderer;
    ParticleSystem _particles;

	public float Angle {
		get { return transform.rotation.eulerAngles.z; }
	}

	void Awake() {
		_spriteRenderer = GetComponent<SpriteRenderer>();
        _particles = GetComponent<ParticleSystem>();

		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}
		UpdateColor();
	}

	public Constants.Type GetColor() {
		return _color;
	}

	void UpdateColor() {
        ParticleSystem.MainModule settings = _particles.main;

        switch (_color) {
			case Constants.Type.RED:
				_spriteRenderer.color = Color.red;
                settings.startColor = Color.red;
                break;
			case Constants.Type.GREEN:
				_spriteRenderer.color = Color.green;
                settings.startColor = Color.green;
                break;
			case Constants.Type.BLUE:
				_spriteRenderer.color = Color.blue;
                settings.startColor = Color.blue;
                break;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.GetComponent<BallAttribute>()) {
			BallAttribute ball = other.GetComponent<BallAttribute>();
			if (ball.GetColor() != _color) {
				_color = ball.GetColor();
				UpdateColor();
			}
            _particles.Play();
		}
	}
}
