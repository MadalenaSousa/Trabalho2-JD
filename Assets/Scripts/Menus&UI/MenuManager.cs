using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject confirmationPanel;

    private void Start()
    {
        if(confirmationPanel != null)
        {
            confirmationPanel.SetActive(false);
        }
    }

    public void openConfirmPanel()
    {
        confirmationPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeConfirmPanel()
    {
        confirmationPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void playGame()
    {
        SceneManager.LoadScene("InitialCutscene");
    }

    public void restart()
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

    public void closePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
