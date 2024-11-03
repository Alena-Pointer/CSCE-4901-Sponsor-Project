using UnityEngine;

public class ShipBounceController : MonoBehaviour
{
    public ShipHealth playerHealth; // Reference to the ShipHealth component on the player

    private void OnCollisionEnter(Collision collision)
    {
        // Assuming you want to apply damage when the player collides with certain objects
        if (collision.gameObject.CompareTag("Asteroid")) // Replace with relevant tag
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(5); // Deal 5 damage, for example
            }
            else
            {
                Debug.LogError("Player Health reference is not assigned in ShipBounceController!");
            }
        }
    }
}
