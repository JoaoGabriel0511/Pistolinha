using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttribute : MonoBehaviour, IColorful {
	[SerializeField] Constants.Type ballType;
	[SerializeField] float speed;

	public Constants.Type GetColor() {
		return ballType;
	}

	public float GetSpeed() {
		return speed;
	}

	void OnCollisionEnter2D(Collision2D collision2D) {
		IColorful iColorful = collision2D.gameObject.GetComponent<IColorful>();
		Debug.Log("Colidiu");
	}
}
