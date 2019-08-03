using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //  Internal references
    Rigidbody2D rb2D;

    //  attributes
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector3 direction)
    {
        rb2D.velocity = speed * direction.normalized;
    }
}
