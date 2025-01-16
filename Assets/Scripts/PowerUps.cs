using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerup", menuName = "Powerup/New Powerup")]
public class PowerUps : ScriptableObject
{
    public string powerupName;
    public Sprite icon;

    public void Apply()
    {
        switch (powerupName)
        {
            case "Increased Mobility":
                FindFirstObjectByType<PlayerMovement>().ApplyMobilityBoost();
                break;

            case "Increased Damage":
                // Apply the damage boost globally using the static class
                DamageModifier.ApplyDamageBoost(1.6f); // Example multiplier (adjust as needed)
                break;

            case "Bigger Flashlight":
                FindFirstObjectByType<BiggerFlashlight>().IncreaseFlashlight();
                break;

            default:
                Debug.LogWarning("Unknown powerup: " + powerupName);
                break;
        }
    }
}
