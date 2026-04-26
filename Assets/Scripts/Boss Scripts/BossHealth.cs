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
    public BossHealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar == null)
            healthBar = FindObjectOfType<BossHealthBar>();
        if (healthBar != null)
            healthBar.SetHealth(currentHealth, maxHealth);
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
        Destroy(gameObject);
        FindObjectOfType<GameManager>().BossDefeated();
        if (doorToUnlock != null)
            doorToUnlock.SetActive(false);
    }
}