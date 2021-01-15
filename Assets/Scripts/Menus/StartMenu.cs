using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void stopAllSounds()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
