using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoost", menuName = "Powerup/SpeedBoost")]
public class FasterSpeedsPowerup : PermanentPowerupData
{
    public float speedMultiplier = 1.5f; // Default value for speed multiplier
    public float runCostMultiplier = 0.5f; // Default value for run cost multiplier

    public void ApplyEffect(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.ApplyMobilityBoost(speedMultiplier, runCostMultiplier);
        }
    }
}
