using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerGold playerGold = other.GetComponent<PlayerGold>();
            if (playerGold != null) playerGold.AddGold(value);
            Destroy(gameObject);
        }
    }
}
