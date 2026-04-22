using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int currentLevel = 1;
    public int totalLevels = 2;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > totalLevels)
        {
            WinGame();
        }
        else
        {
            //SceneManager.LoadScene("Level" + currentLevel);
        }
    }

    public void WinGame()
    {
        Debug.Log("YOU WIN! Game completed.");
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
