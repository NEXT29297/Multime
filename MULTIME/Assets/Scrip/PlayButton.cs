using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("World2");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Start()
    {

    }


    void Update()
    {

    }
}