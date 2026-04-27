using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomManager : MonoBehaviour
{
    public GameObject exitDoor;
    public TextMeshProUGUI clearMessageUI;
    private int enemiesRemaining = 0;
    private bool isCleared = false;

    void Start()
    {
        CountEnemies();
        if (exitDoor != null)
            exitDoor.SetActive(false);
        if (clearMessageUI != null)
            clearMessageUI.gameObject.SetActive(false);
    }

    void CountEnemies()
    {
        EnemyHealth[] enemies = GetComponentsInChildren<EnemyHealth>();
        enemiesRemaining = enemies.Length;
    }

    public void EnemyDied()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0 && !isCleared)
        {
            isCleared = true;
            StartCoroutine(ShowClearMessageAndUnlock());
        }
    }

    IEnumerator ShowClearMessageAndUnlock()
    {
        if (clearMessageUI != null)
        {
            clearMessageUI.text = "Room Clear!";
            clearMessageUI.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            clearMessageUI.gameObject.SetActive(false);
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        if (exitDoor != null)
            exitDoor.SetActive(true);
    }
}
