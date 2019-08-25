using UnityEngine.UI;
using UnityEngine;

public class QuitButton : MonoBehaviour {
	Button btn;

	void Start() {
		btn = GetComponent<Button>();

		if (!btn) {
			Debug.Log("Button component doesn't exist!");
		}
		else {
			btn.onClick.AddListener(QuitGame);
		}
	}

	void QuitGame() {
		Application.Quit();
	}
}
