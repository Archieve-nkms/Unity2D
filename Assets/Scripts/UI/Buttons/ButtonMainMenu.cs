using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}