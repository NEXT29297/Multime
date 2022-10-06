using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectItem : MonoBehaviour
{
    GetInSpaceship getInSpaceship;
    public GameObject spaceship;

    public int itemCount;
    [SerializeField] public Text itemCountText;
    public GameObject textbox;

    private void Awake()
    {
        getInSpaceship =spaceship.GetComponent<GetInSpaceship>();
    }
    void Start()
    {
        itemCountText.text = "0/3";
        textbox.SetActive(false);
    }
    void Update()
    {
        getInSpaceship.item = itemCount;
    }

    private void OnTriggerEnter2D(Collider2D item)
    {   
        if (item.CompareTag("Item"))
        {   
            Destroy(item.gameObject);
            textbox.SetActive(true);
            itemCount++;
            itemCountText.text = itemCount + "/3";
        }
    }

}
