using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject

{

    [Header("UI")]
    public Sprite crosshairSprite;

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
    public int damage;

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
