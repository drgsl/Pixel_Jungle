using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public static GameObject mainMenuScreen;
    public static GameObject selectScreen;
    public static GameObject optionsScreen;
    public static GameObject quitPopup;


    private void Awake()
    {
        mainMenuScreen = GameObject.FindGameObjectWithTag("MainMenu/MainMenu");
        selectScreen = GameObject.FindGameObjectWithTag("MainMenu/SelectGame");
        optionsScreen = GameObject.FindGameObjectWithTag("MainMenu/Options");
        quitPopup = GameObject.FindGameObjectWithTag("MainMenu/QuitPopup");
    }

    private void Start()
    {
        //closeQuit();
        closeSelect();
        closeOptions();
        openMainMenu();
    }

    public static void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public static void quitGame()
    {
        Application.Quit();
    }

    public static void closeMainMenu()
    {
        mainMenuScreen.SetActive(false);
    }

    public static void openMainMenu()
    {
        mainMenuScreen.SetActive(true);
    }


    public static void closeSelect()
    {
        selectScreen.SetActive(false);
    }

    public static void openSelect()
    {
        selectScreen.SetActive(true);
    }


    public static void closeOptions()
    {
        optionsScreen.SetActive(false);
    }

    public static void openOptions()
    {
        optionsScreen.SetActive(true);
    }


    public static void closeQuit()
    {
        quitPopup.SetActive(false);
    }

    public static void openQuit()
    {
        quitPopup.SetActive(true);
    }
}
