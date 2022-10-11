using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHold : MonoBehaviour
{
    private bool Playerinrange;
    public Transform Player;
    public Transform GrabPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E) && Playerinrange == true)
        {
            gameObject.transform.SetParent(Player.transform);
            gameObject.transform.position = GrabPosition.position;
           
        }
        else 
        {
            gameObject.transform.parent = null;
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxCheck"))
        {
            Playerinrange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Playerinrange = false;
    }
}
