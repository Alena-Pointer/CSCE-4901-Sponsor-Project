using UnityEngine;
using TMPro;

public class ShipHealth : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI damageTextOverlay;
    public GameUIController uiController;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        uiController.UpdateHearts(health);  // Update hearts and progress bar
        ShowDamageText(amount);

        if (health <= 0)
        {
            health = 0;
            gameOverText.gameObject.SetActive(true);  // Show Game Over text
            // Optionally stop the game here
        }
    }

    void ShowDamageText(int damageAmount)
    {
        damageTextOverlay.text = $"-{damageAmount} Health";
        damageTextOverlay.gameObject.SetActive(true);
        Invoke("HideDamageText", 1.5f); // Hide after 1.5 seconds
    }

    void HideDamageText()
    {
        damageTextOverlay.gameObject.SetActive(false);
    }
}
