using UnityEngine.UI;
using UnityEngine;

public class ColorSelectionButton : MonoBehaviour {
	[SerializeField] Constants.Type tipo = Constants.Type.NONE;
	[SerializeField] Cannon cannon;
	Button btn;

	void Start() {
		cannon = FindObjectOfType<Cannon>();
		btn = GetComponent<Button>();

		if (!cannon) {
			Debug.Log("Cannon not found!");
		}
		else {
			if (!cannon.ColorIsEnable(tipo)) {
				gameObject.SetActive(false);
			}
		}
		if (!btn) {
			Debug.Log("Button component doesn't exist!");
		}
		else {
			btn.onClick.AddListener(ChangeColor);
		}
	}

	void ChangeColor() {
		if (cannon) {
			cannon.ChangeColor(tipo);
		}
	}
}
