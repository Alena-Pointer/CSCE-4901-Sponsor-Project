using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUIController : MonoBehaviour
{
    public List<Image> heartIcons;        // List of heart icons
    public ShipHealth playerHealth;       // Reference to the player’s health script
    public Image progressBar;             // Progress bar image for health

    // Update the hearts display based on the player’s current health
    public void UpdateHearts(int currentHealth)
    {
        int heartsToDisplay = currentHealth / 20; // Each heart represents 20 health

        for (int i = 0; i < heartIcons.Count; i++)
        {
            heartIcons[i].enabled = i < heartsToDisplay;
        }

        UpdateProgressBar(currentHealth);
    }

    // Update the progress bar fill based on health
    private void UpdateProgressBar(int currentHealth)
    {
        if (progressBar != null)
        {
            progressBar.fillAmount = currentHealth / 100f; // Assuming max health is 100
        }
    }
}
