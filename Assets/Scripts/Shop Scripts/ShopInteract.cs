using UnityEngine;
using TMPro;

public class ShopInteract : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject interactPrompt;

    private bool playerInRange = false;

    void Start()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed, shopUI is " + (shopUI != null ? shopUI.activeSelf.ToString() : "null"));
            
            if (shopUI != null)
            {
                bool isActive = shopUI.activeSelf;
                shopUI.SetActive(!isActive);
                Debug.Log("Shop UI now: " + shopUI.activeSelf);
                
                // Hide prompt when shop opens
                if (interactPrompt != null && !isActive)
                    interactPrompt.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactPrompt != null && (shopUI == null || !shopUI.activeSelf))
                interactPrompt.SetActive(true);
            Debug.Log("Player entered shop trigger. Prompt active: " + (interactPrompt != null && interactPrompt.activeSelf));
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
            Debug.Log("Player exited shop trigger. UI closed.");
        }
    }
}