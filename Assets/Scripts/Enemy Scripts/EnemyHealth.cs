using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public GameObject goldPrefab;
    public int goldAmount = 10;
    private RoomManager roomManager;

    void Start()
    {
        currentHealth = maxHealth;
        roomManager = GetComponentInParent<RoomManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        EnemyAI enemyAI = GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.Alert();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (goldPrefab != null)
        {
            GameObject gold = Instantiate(goldPrefab, transform.position, Quaternion.identity);
            gold.GetComponent<GoldPickup>().value = goldAmount;
        }
        if (roomManager != null)
            roomManager.EnemyDied();
        Destroy(gameObject);
    }
}
