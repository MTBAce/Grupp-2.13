using UnityEngine;

[CreateAssetMenu(fileName = "NewPermanentPowerUp", menuName = "Powerup/PowerUp")]
public class PermanentPowerupData : ScriptableObject
{
    public string powerupName;
    public Sprite powerUpIcon;

    public void ApplyPowerUp(GameObject player)
    {

    }
    

    
}
