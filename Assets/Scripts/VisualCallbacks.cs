using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisualCallbacks : MonoBehaviour {
	public UnityAction<GameObject> onAnimationFinish;
	public UnityAction<GameObject> onBecameInvisible;

	public void OnAnimationFinish() {
		onAnimationFinish(gameObject);
	}

	public void OnBecameInvisible() {
		onBecameInvisible(gameObject);
	}
}
