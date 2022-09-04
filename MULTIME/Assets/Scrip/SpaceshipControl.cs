using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControl : MonoBehaviour
{
    float horizontal;
    float vertical;
    private Rigidbody2D rb;
    public float speed;
    private Transform BodyTansform;
    public float size;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BodyTansform = GetComponent<Transform>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * Time.deltaTime*speed, vertical * Time.deltaTime*speed);
        if (horizontal != 0f)
        {
            BodyTansform.localScale = new Vector3(horizontal * size, size,size);
        }
    }
}
