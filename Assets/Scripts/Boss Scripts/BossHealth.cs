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

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
        Destroy(gameObject);
        FindObjectOfType<GameManager>().BossDefeated();
        if (doorToUnlock != null)
            doorToUnlock.SetActive(false);
    }
}