using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoost", menuName = "Powerup/SpeedBoost")]
public class FasterSpeedsPowerup : PermanentPowerupData
{
    public float afterSpeedMultiplier;
    public float beforeSpeedMultiplier;

    public float beforeRunCost;
    public float afterRunCost;

    public void ApplyEffect(GameObject player)
    {
        
    }
}
