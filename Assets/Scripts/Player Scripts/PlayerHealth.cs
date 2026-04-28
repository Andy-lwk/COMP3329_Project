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

    private GameOverScreen gameOverScreen;

    void Start()
    {
        currentHealth = maxHealth;
        gameOverScreen = FindObjectOfType<GameOverScreen>();
        if (gameOverScreen == null)
            Debug.LogWarning("GameOverScreen not found in scene!");
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
        if (isInvincible) return;

        currentHealth -= damage;
        Debug.Log("Player took damage! Health: " + currentHealth);

        isInvincible = true;
        invincibilityTimer = invincibilityDuration;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        if (gameOverScreen != null)
            gameOverScreen.ShowGameOver();
        else
            Debug.LogError("Cannot show game over – GameOverScreen missing!");
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
