using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Base Stats")]
    public float baseDamage = 1f;
    public float baseSpeed = 10f;
    public int baseMaxHealth = 5;

    [Header("Upgraded Stats (modified by shop)")]
    public float damageMultiplier = 1f;
    public float speedMultiplier = 1f;
    public int extraMaxHealth = 0;

    public float TotalDamage => baseDamage * damageMultiplier;
    public float TotalSpeed => baseSpeed * speedMultiplier;
    public int TotalMaxHealth => baseMaxHealth + extraMaxHealth;

    public void UpgradeDamage(float increase) { damageMultiplier += increase; }
    public void UpgradeSpeed(float increase) { speedMultiplier += increase; }
    public void UpgradeMaxHealth(int increase) 
    { 
        extraMaxHealth += increase;
        PlayerHealth health = GetComponent<PlayerHealth>();
        if (health != null)
            health.IncreaseMaxHealth(TotalMaxHealth);
    }
}
