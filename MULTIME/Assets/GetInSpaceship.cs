using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetInSpaceship : MonoBehaviour
{
    //public GameObject player;
    public GameObject getInButton;
    public int item;

    void Start()
    { 
        getInButton.SetActive(false);
    }

    void Update()
    {
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && item == 3)
        {
            getInButton.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("inSpaceship");
            }
        }
        else
        {
            getInButton.SetActive(false);
        }
    }
}
