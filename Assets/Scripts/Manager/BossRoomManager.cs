using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossRoomManager : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;
    public GameObject exitDoor;
    public TextMeshProUGUI clearMessageUI;

    private bool bossSpawned = false;
    private bool bossDefeated = false;

    void Start()
    {
        if (exitDoor != null)
            exitDoor.SetActive(false);
        if (clearMessageUI != null)
            clearMessageUI.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("BossRoomManager: OnTriggerEnter2D by " + other.name);
        if (other.CompareTag("Player") && !bossSpawned)
        {
            bossSpawned = true;
            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
            BossHealth bh = bossPrefab.GetComponent<BossHealth>();
            if (bh != null)
            {
                bh.SetRoomManager(this);
                Debug.Log("BossRoomManager: SetRoomManager called on boss");
            }
            else
                Debug.LogError("Boss prefab has no BossHealth script!");
        }
    }

    public void BossDefeated()
    {
        if (bossDefeated) return;
        print("Boss defeated! Unlocking exit...");
        bossDefeated = true;
        StartCoroutine(ShowClearMessageAndUnlock());
    }

    IEnumerator ShowClearMessageAndUnlock()
    {
        if (clearMessageUI != null)
        {
            clearMessageUI.text = "Boss Defeated!";
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
