using UnityEngine;

public class HealingObject : MonoBehaviour
{
    public float healAmount = 20f; // Amount of health to restore

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the object that entered the trigger has the "Player" tag
        if (collider.CompareTag("Player"))
        {
            // Attempt to get the PlayerHealth component on the player
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Heal the player
                playerHealth.Heal(healAmount);

                // Optionally destroy this healing object
                Destroy(gameObject);
            }
        }
    }
}
