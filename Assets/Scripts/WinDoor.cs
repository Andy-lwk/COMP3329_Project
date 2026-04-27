using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDoor : MonoBehaviour
{
    public WinScreen winScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (winScreen != null)
                winScreen.ShowWinScreen();
            else
                Debug.LogError("WinScreen reference missing on door!");
        }
    }
}
