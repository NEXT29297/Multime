using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcollecting : MonoBehaviour
{
    public GameObject ebutton;
    int wrie, ironplate, energybar;

    void Start()
    {
        ebutton.SetActive(false);
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.CompareTag("Energy"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(item.gameObject);
                energybar++;
                Debug.Log("energy"+energybar);
            }
            
        }
      if (item.CompareTag("Wrie"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(item.gameObject);
                wrie++;
                Debug.Log("wrie"+wrie);
            }
            
        }  
    }
}
