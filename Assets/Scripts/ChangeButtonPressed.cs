using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButtonPressed : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	Image img;
	[SerializeField] Sprite up;
	[SerializeField] Sprite down;

	void Start() {
		img = GetComponent<Image>();

		if (!img) {
			Debug.Log("Image component doesn't exist!");
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		img.sprite = up;
	}

	public void OnPointerDown(PointerEventData eventData) {
		img.sprite = down;
	}
}
