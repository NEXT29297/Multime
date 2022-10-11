using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    Collider2D collider2d;
    Rigidbody2D rb;

    public float horizontalmove = 0f;
    public float speed = 350f;  
    public float jump = 7f;
    public bool isjump = false;
    Animator PlayerAnimatorController;
    public Transform BodyTransform;
    public float size;
    
    public bool onItemHaveDialog;

    public bool dialogIsPlaying;
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimatorController = GetComponent<Animator>();            
    }
    void Update()
    {           
        if(dialogIsPlaying == true)
        {
            speed = 0f;
            jump = 0f;
            horizontalmove = 0;
            isjump = false;
            rb.velocity = new Vector2(0, 0);
           
        }

        if(dialogIsPlaying == false)
        {            
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = 1000f;
                }               
                else
                {
                    speed = 350f;
                }            
            jump = 7f;

            horizontalmove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);

            if (horizontalmove != 0f)
            {
                 
                PlayerAnimatorController.SetBool("IsMoving", true);
                BodyTransform.localScale = new Vector3(size*horizontalmove, size, 1);
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
    }
    void jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isjump = true;
        PlayerAnimatorController.SetBool("isJumping", true);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        { 
            isjump = false;
            PlayerAnimatorController.SetBool("isJumping", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("HaveDialog"))
        {
            onItemHaveDialog = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onItemHaveDialog = false;
    }

}
