using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("Player References")]
    public PlayerStats playerStats;
    public PlayerGold playerGold;

    [Header("UI")]
    public TextMeshProUGUI goldText;

    [Header("Upgrade Costs & Amounts")]
    public int damageCost = 30;
    public float damageIncrease = 0.5f;

    public int speedCost = 20;
    public float speedIncrease = 0.2f;

    public int healthCost = 25;
    public int healthIncrease = 2;

    void Start()
    {
        if (playerStats == null)
            playerStats = FindObjectOfType<PlayerStats>();
        if (playerGold == null)
            playerGold = FindObjectOfType<PlayerGold>();
    }

    void Update()
    {
        if (goldText != null && playerGold != null)
            goldText.text = "Gold: " + playerGold.gold;
    }

    public void BuyDamage()
    {
        if (playerGold.gold >= damageCost)
        {
            playerGold.AddGold(-damageCost);
            playerStats.UpgradeDamage(damageIncrease);
            Debug.Log("Damage upgraded! Multiplier: " + playerStats.damageMultiplier);
        }
        else Debug.Log("Not enough gold for Damage upgrade!");
    }

    public void BuySpeed()
    {
        if (playerGold.gold >= speedCost)
        {
            playerGold.AddGold(-speedCost);
            playerStats.UpgradeSpeed(speedIncrease);
            Debug.Log("Speed upgraded! Multiplier: " + playerStats.speedMultiplier);
        }
        else Debug.Log("Not enough gold for Speed upgrade!");
    }

    public void BuyHealth()
    {
        if (playerGold.gold >= healthCost)
        {
            playerGold.AddGold(-healthCost);
            playerStats.UpgradeMaxHealth(healthIncrease);
            Debug.Log("Max Health increased to " + playerStats.TotalMaxHealth);
        }
        else Debug.Log("Not enough gold for Health upgrade!");
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
