using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayAutoGame()
    {
        SceneManager.LoadScene("AutomotiveFacts");
        Debug.Log("Playing Automotive game!");
    }

    public void PlayEngineerGame()
    {
        Debug.Log("Playing Engineering game!");
    }

    public void OpenSettings()
    {
        Debug.Log("Opening settings!");
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game!");
        Application.Quit();
    }

    private void OnMouseEnter()
    {
    }

}
