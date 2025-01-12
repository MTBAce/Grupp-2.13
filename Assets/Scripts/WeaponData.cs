using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header ("Weapon Data")]
    
    public string weaponName;
    public string weaponAnimation;
    public float bulletForce;
    public float fireRate ;
    public float spreadAngle;
    public int pelletCount;

    [Header("Screenshake")]
    public float magnitude;
    public float duration;

}