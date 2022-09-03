using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectItem : MonoBehaviour
{
    bool energyBar;
    bool wrie;
    bool ironPlate;

    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.CompareTag("Energy"))
        {
            energyBar = true;
        }
        if (item.CompareTag("Wrie"))
        {
            wrie = true;
        }
        if (item.CompareTag("IronPlate"))
        {
            ironPlate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D item)
    {
        energyBar = false;
        wrie = false;
        ironPlate = false;
    }
}