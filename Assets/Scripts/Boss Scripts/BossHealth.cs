using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 15;
    private int currentHealth;
    public GameObject goldPrefab;
    public int goldAmount = 50;
    public GameObject doorToUnlock;
    public GameObject healthBarPrefab;
    public BossHealthBar healthBar;
    private BossRoomManager bossRoom;


    void Start()
    {
        currentHealth = maxHealth;
        if (healthBarPrefab != null)
        {
            GameObject barObj = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
            healthBar = barObj.GetComponent<BossHealthBar>();
            if (healthBar != null)
            {
                healthBar.bossTransform = transform;
                healthBar.SetHealth(currentHealth, maxHealth);
            }
        }
        if (bossRoom == null)
        {
            bossRoom = FindObjectOfType<BossRoomManager>();
            if (bossRoom != null)
                Debug.Log("BossHealth: Found BossRoomManager via FindObjectOfType");
            else
                Debug.LogError("BossHealth: No BossRoomManager found in scene!");
        }
    }

    public void SetRoomManager(BossRoomManager manager)
    {
        bossRoom = manager;
    }

    public void TakeDamage(int damage)
    {
        print("Boss takes " + damage + " damage!");
        currentHealth -= damage;
        if (healthBar != null)
            healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        if (goldPrefab != null)
        {
            GameObject gold = Instantiate(goldPrefab, transform.position, Quaternion.identity);
            gold.GetComponent<GoldPickup>().value = goldAmount;
        }
        if (healthBar != null)
            healthBar.SetHealth(0, maxHealth);

        if (bossRoom != null)
            bossRoom.BossDefeated();
        else
            Debug.LogError("BossRoomManager reference missing! Did you set it on spawn?");

        Destroy(gameObject);
    }
}