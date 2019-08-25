using UnityEngine;

public class KillOutOfVision : MonoBehaviour {
	void OnBecameInvisible() => Destroy(transform.parent.gameObject);
}
