using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttribute : MonoBehaviour, IColorful {
	[SerializeField] Constants.Type ballType;
	[SerializeField] float speed;
	public GameObject explosionParticle = null;
    public BallCollisionBehaviour collisionBehaviour;
	bool _isColiding;
    
	public Constants.Type GetColor() {
		return ballType;
	}

	public float GetSpeed() {
		return speed;
	}

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

	public void SetColiding(bool flag) {
		_isColiding = flag;
	}

	public bool IsColiding() {
		return _isColiding;
	}
}
