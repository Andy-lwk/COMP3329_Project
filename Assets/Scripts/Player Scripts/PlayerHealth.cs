using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth{ get; private set; }

    public float invincibilityDuration = 1f;
    private float invincibilityTimer = 0f;
    private bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
                // Optional: make player sprite blink back to normal
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;  // Ignore damage if invincible

        currentHealth -= damage;
        Debug.Log("Player took damage! Health: " + currentHealth);

        isInvincible = true;
        invincibilityTimer = invincibilityDuration;

        // Optional: make player sprite blink or flash
        // (you can add a simple coroutine to change alpha)

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // GameManager.Instance.GameOver();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IncreaseMaxHealth(int newMax)
    {
        maxHealth = newMax;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
}
