using UnityEngine;
using TMPro;

public class ShopInteract : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject interactPrompt;

    private bool playerInRange = false;

    void Start()
    {
        if (shopUI != null)
            shopUI.SetActive(false);
        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bool isActive = shopUI.activeSelf;
            shopUI.SetActive(!isActive);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactPrompt != null)
                interactPrompt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (shopUI != null)
                shopUI.SetActive(false);
            if (interactPrompt != null)
                interactPrompt.SetActive(false);
        }
    }
}