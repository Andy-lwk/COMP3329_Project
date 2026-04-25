using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;
    public GameObject doorToLock;
    private bool bossSpawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !bossSpawned)
        {
            bossSpawned = true;
            Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
            if (doorToLock != null)
                doorToLock.SetActive(true);
        }
    }
}
