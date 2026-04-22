using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int damageUpgradeCost = 30;
    public int speedUpgradeCost = 20;
    public int healthUpgradeCost = 25;

    public float damageIncrease = 0.5f;
    public float speedIncrease = 0.2f;
    public int healthIncrease = 2;

    private bool playerInRange = false;
    private PlayerStats playerStats;
    private PlayerGold playerGold;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerStats = other.GetComponent<PlayerStats>();
            playerGold = other.GetComponent<PlayerGold>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerStats = null;
            playerGold = null;
        }
    }

    void Update()
    {
        if (!playerInRange || playerStats == null || playerGold == null) return;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            BuyDamage();
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            BuySpeed();
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            BuyHealth();
    }

    void BuyDamage()
    {
        if (playerGold.gold >= damageUpgradeCost)
        {
            playerGold.AddGold(-damageUpgradeCost);
            playerStats.UpgradeDamage(damageIncrease);
            Debug.Log("Damage upgraded! Multiplier: " + playerStats.damageMultiplier);
        }
        else Debug.Log("Not enough gold for damage upgrade");
    }

    void BuySpeed()
    {
        if (playerGold.gold >= speedUpgradeCost)
        {
            playerGold.AddGold(-speedUpgradeCost);
            playerStats.UpgradeSpeed(speedIncrease);
            Debug.Log("Speed upgraded! Multiplier: " + playerStats.speedMultiplier);
        }
        else Debug.Log("Not enough gold for speed upgrade");
    }

    void BuyHealth()
    {
        if (playerGold.gold >= healthUpgradeCost)
        {
            playerGold.AddGold(-healthUpgradeCost);
            playerStats.UpgradeMaxHealth(healthIncrease);
            Debug.Log("Health upgraded! Max health: " + playerStats.TotalMaxHealth);
        }
        else Debug.Log("Not enough gold for health upgrade");
    }
}
