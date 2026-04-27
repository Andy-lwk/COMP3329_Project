using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winPanel;

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void ShowWinScreen()
    {
        if (winPanel != null)
            winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
