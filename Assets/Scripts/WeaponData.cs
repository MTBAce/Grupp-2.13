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
    public int currentAmmo;
    public int startingAmmo;
    public int ammoBoxAmount;

    [Header("Screenshake")]
    public float magnitude;
    public float duration;

    [Header("Movement")]
    public float moveSpeed;
    public float gunFollowSpeed;
    public float sprintSpeed;
    public float runCost;

    [Header("Sound")]
    public AudioClip shootSound;


}
