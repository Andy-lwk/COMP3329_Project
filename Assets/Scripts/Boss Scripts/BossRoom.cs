using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform bossSpawnPoint;
    public GameObject doorToLock;
    private bool bossSpawned = false;
    public GameObject bossHealthBarPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !bossSpawned)
        {
            bossSpawned = true;
            GameObject boss = Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
            GameObject bar = Instantiate(bossHealthBarPrefab);
            BossHealthBar barScript = bar.GetComponent<BossHealthBar>();
            barScript.bossTransform = boss.transform;
            BossHealth bossHealth = boss.GetComponent<BossHealth>();
            bossHealth.healthBar = barScript;
            if (doorToLock != null)
                doorToLock.SetActive(true);
        }
    }
}
