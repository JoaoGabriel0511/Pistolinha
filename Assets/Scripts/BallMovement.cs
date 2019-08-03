using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //  Internal references
    Rigidbody2D rb2D;

    //  attributes
    public float speed;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Debug.Log("awake");
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
        rb2D.velocity = speed * Vector3.right;
    }
}
