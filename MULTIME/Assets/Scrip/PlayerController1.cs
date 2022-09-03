using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    Collider2D collider2d;
    Rigidbody2D rb;

    float horizontalmove = 0f;
    public float speed = 350f;  
    public float jump = 7f;
    bool isjump = false;
    Animator PlayerAnimatorController;
    public Transform BodyTransform;

    public bool letgo = true;

    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimatorController = GetComponent<Animator>();
        
    }
    void Update()
    {

        horizontalmove = Input.GetAxisRaw("Horizontal");           

        rb.velocity = new Vector2(horizontalmove*speed*Time.deltaTime, rb.velocity.y);

        if(horizontalmove != 0f)
        {
           PlayerAnimatorController.SetBool("IsMoving", true);
           BodyTransform.localScale = new Vector3(1.5f*horizontalmove, 1.5f, 1);
        }
        else
        {
            PlayerAnimatorController.SetBool("IsMoving", false);
        }
        
        if (Input.GetButtonDown("Jump") && isjump == false)
        {
            PlayerAnimatorController.SetBool("isJumping", true);
            jumping();
            
        }
 
    }
    void jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isjump = false;
            PlayerAnimatorController.SetBool("isJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isjump = true;   
    }
    
    public void canMove(bool move)
    {
        if (move == false)
        {
            letgo = false;
        }
    }
}
