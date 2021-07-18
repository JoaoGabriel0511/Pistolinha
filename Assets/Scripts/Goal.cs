using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour {
	[SerializeField] Constants.Type _goalType;
	[SerializeField] Sprite red;
	[SerializeField] Sprite blue;
	[SerializeField] Sprite green;
	SpriteRenderer _spriteRenderer;

	public UnityEvent StageCleared;


	void Awake() {
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}

		switch (_goalType) {
			case Constants.Type.RED:
				_spriteRenderer.sprite = red;
				break;
			case Constants.Type.BLUE:
				_spriteRenderer.sprite = blue;
				break;
			case Constants.Type.GREEN:
				_spriteRenderer.sprite = green;
				break;
			default:
				break;
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<BallAttribute>()) {
			BallAttribute ball = other.GetComponent<BallAttribute>();
			if (ball.GetColor() == _goalType) {
				StageCleared?.Invoke();
				_spriteRenderer.color = Color.yellow;
			}
			Instantiate(ball.explosionParticle, transform.position, Quaternion.identity);
			Destroy(ball.gameObject);
		}
	}
}
