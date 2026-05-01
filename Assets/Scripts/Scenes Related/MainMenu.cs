using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject mainMenuButtons;

    void Start()
    {
        if (howToPlayPanel != null)
            howToPlayPanel.SetActive(false);
        if (mainMenuButtons != null)
            mainMenuButtons.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void ShowHowToPlay()
    {
        if (howToPlayPanel != null)
            howToPlayPanel.SetActive(true);
        if (mainMenuButtons != null)
            mainMenuButtons.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
            howToPlayPanel.SetActive(false);
        if (mainMenuButtons != null)
            mainMenuButtons.SetActive(true);
    }
}