using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3;
    Rigidbody2D rigid2D;
    public Transform BodyTransform;
    Animator PlayerAnimatorController;
    private bool triggerActive = false;
    public Text TextHI;
    public float time = 5;
    private bool Countdown = false;
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        PlayerAnimatorController = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerAnimatorController.SetBool("IsMoving", true);
            rigid2D.AddForce(Vector3.right * Speed);
            BodyTransform.localScale = new Vector3(2f, 2f, 1);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerAnimatorController.SetBool("IsMoving", true);
            rigid2D.AddForce(Vector3.left * Speed);
            BodyTransform.localScale = new Vector3(-2f, 2f, 1);
        }
        if (rigid2D.velocity == Vector2.zero)
        {
            PlayerAnimatorController.SetBool("IsMoving", false);
        }
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            SomeCoolAction();
            Countdown = true;
        }
        if (Countdown ==true)
        {
            CountDown();
            Speed = 0;
        }
        if (time <= 0)
        {
            TextHI.enabled = false;
            Countdown = false;
            time = 10;
            Speed = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Detective"))
        {
            triggerActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerActive = false;

    }
    public void SomeCoolAction()
    {

        TextHI.text = "HIIIIIIIIIIIIII";
        TextHI.enabled = true;
    }
    public void CountDown()
    {
        time -= Time.deltaTime;
    }
}

