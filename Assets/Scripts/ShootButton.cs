using UnityEngine.UI;
using UnityEngine;

public class ShootButton : MonoBehaviour {
	[SerializeField] Cannon cannon;
	Button btn;

	void Start() {
		cannon = FindObjectOfType<Cannon>();
		btn = GetComponent<Button>();

		if (!cannon) {
			Debug.Log("Cannon not found!");
		}
		if (!btn) {
			Debug.Log("Button component doesn't exist!");
		}
		else {
			btn.onClick.AddListener(Shoot);
		}
	}

	void Shoot() {
		if (cannon) {
			cannon.Shoot();
		}
	}
}
