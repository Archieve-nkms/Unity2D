using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInGame : MonoBehaviour
{
    public void RestartGame()
    {
        this.gameObject.SetActive(false);
        Managers.Game.StartGame();
    }

    public void BackToTitle()
    {
        Managers.Game.ProceedGame();
        SceneManager.LoadScene("MainMenu");
    }
}