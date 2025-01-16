using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "NewPowerup", menuName = "Powerup/New Powerup")]
public class PowerUps : ScriptableObject
{
    public string powerupName;
    public Sprite icon;
    public float value;

    public void Apply(GameObject player)
    {
        switch (powerupName)
        {
            case "SpeedBoost":
                player.GetComponent<PlayerMovement>().ApplyMobilityBoost(value);
                break;

            case "WeaponDamage":
               // player.GetComponent<PlayerWeaponHandler>().BoostDamage(value);
                break;

            case "FlashlightRange":
                //player.GetComponent<PlayerFlashlight>().IncreaseRange(value);
                break;

            default:
                //Debug.LogWarning("Unknown powerup: " + powerupName);
                break;
        }
    }
}
