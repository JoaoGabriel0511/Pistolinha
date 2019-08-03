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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Yup");
        if (other.GetComponent<IColorful>() != null) {
            Debug.Log("Yup2");
            Wall wall = other.GetComponent<Wall>();
            if(wall != null)
            {
                Debug.Log("Yup3");
                if ( Mathf.Approximately(Mathf.Abs(Mathf.DeltaAngle(wall.Angle.z, transform.rotation.eulerAngles.z)), 90) )
                {
                    Debug.Log("Yup4");
                    if(transform.rotation.eulerAngles.z < 0)
                        transform.eulerAngles = Vector3.forward * (180 + (int)transform.eulerAngles.z) ; 
                    else
                        transform.eulerAngles = Vector3.forward * (-180 + (int)transform.eulerAngles.z);
                }
                else
                {
                    if( ((int) transform.rotation.eulerAngles.z) % 180 == 0)
                        transform.eulerAngles = Vector3.forward * ( ((int)wall.Angle.z * 2 + (int)transform.eulerAngles.z) % 360);
                    else transform.eulerAngles = Vector3.forward * (((int)wall.Angle.z * -2 + (int)transform.eulerAngles.z) % 360);
                }
                Vector3 temp = rb2D.velocity;
                rb2D.velocity = transform.right * temp.magnitude;
            }
        }
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
        rb2D.velocity = speed * Vector3.right;
    }
}
