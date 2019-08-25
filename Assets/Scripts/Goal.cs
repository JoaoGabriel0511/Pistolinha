using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour {
	[SerializeField] Constants.Type _goalType;
	SpriteRenderer _spriteRenderer;

    public UnityEvent StageCleared;


	void Awake() {
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}

		switch (_goalType) {
			case Constants.Type.RED:
				_spriteRenderer.color = Color.red;
				break;
			case Constants.Type.BLUE:
				_spriteRenderer.color = Color.blue;
				break;
			case Constants.Type.GREEN:
				_spriteRenderer.color = Color.green;
				break;
			default:
				break;
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("AQUI1");
		if (other.GetComponent<BallAttribute>()) {
            Debug.Log("AQUI2");
            BallAttribute ball = other.GetComponent<BallAttribute>();
			if (ball.GetColor() == _goalType) {
                Debug.Log("AQUI3");
                GameManager.Instance.StageCleared();
                StageCleared?.Invoke();
				_spriteRenderer.color = Color.yellow;
			}
		}
	}
}
