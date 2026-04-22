using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI weaponText;
    
    private PlayerHealth playerHealth;
    private PlayerGold playerGold;
    private PlayerAttack playerAttack;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            playerGold = player.GetComponent<PlayerGold>();
            playerAttack = player.GetComponent<PlayerAttack>();
        }
    }

    void Update()
    {
        if (playerHealth != null)
            healthText.text = "Health: " + playerHealth.currentHealth + " / " + playerHealth.maxHealth;
        
        if (playerGold != null)
            goldText.text = "Gold: " + playerGold.gold;
        
        if (playerAttack != null)
        {
            string weaponName = (playerAttack.currentWeapon == 1) ? "Briefcase" : "Seatbelt";
            weaponText.text = "Weapon: " + weaponName;
        }
    }
}
