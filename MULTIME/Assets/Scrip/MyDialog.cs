using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public bool playerInRange = false;
    [TextArea(3,10)]
    public string[] sentenses;
    public int index;
    public Text textComponent;
    public float textSpeed;


    void Start()
    {
        textComponent.text = string.Empty;
        dialogBox.SetActive(false);
        StartDialog();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange ==true)
        {
            if (textComponent.text == sentenses[index])
            {
                dialogBox.SetActive(true);
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = sentenses[index];
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
    IEnumerator TypeLine()
    {
        foreach (var c in sentenses[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < sentenses.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogBox.SetActive(false);
            index = 0;
        }
    }
    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

}