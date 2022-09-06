using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{   
    public Rigidbody2D RB;
    public BoxCollider2D Collider;

    public float speed = -1.5f;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();

        Collider.enabled = false;

        RB.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        if (transform.position.x < -19)
        {
            transform.position =new  Vector2(18, 0);
        }
    }
}
