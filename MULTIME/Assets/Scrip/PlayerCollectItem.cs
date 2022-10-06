using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectItem : MonoBehaviour
{
    private int energyBarcount, wriecount, ironPlatecount;
    [SerializeField] public Text energyCountText;
    public GameObject textbox;
    void Start()
    {
        energyCountText.text = "0/3";
        textbox.SetActive(false);
    }
    void Update()
    {   
        
    }

    private void OnTriggerEnter2D(Collider2D item)
    {   
        if (item.CompareTag("Energy"))
        {   
            Destroy(item.gameObject);
            textbox.SetActive(true);
            energyBarcount++;
            energyCountText.text = energyBarcount + "/3";
        }
    }

}
