using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PauseFunctions))]
public class pauseMenu : PauseFunctions 
{
    public GameObject settingsMenu;

    public void ResumeGame()
    {
        unPause();
    }
    public void OpenSettings()
    {
        //settingsMenu.SetActive(true);
    }
    public void ExitToMainMenu()
    {
        Paused = false;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
