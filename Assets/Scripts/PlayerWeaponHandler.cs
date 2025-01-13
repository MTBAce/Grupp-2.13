using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public WeaponCore currentWeapon;
    public WeaponData weaponData;
    [SerializeField] GameObject arPrefab;
    [SerializeField] GameObject shotgunPrefab;
    [SerializeField] GameObject smgPrefab;
    [SerializeField] GameObject dualPistolPrefab;

    private WeaponCore ar;
    private WeaponCore shotgun;
    private WeaponCore smg;
    private WeaponCore dualPistol;

    public AudioClip shootSound;    // Ljudklipp för skjutning
    private AudioSource audioSource;


    private void Start()
    {

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Förhindra att ljud spelas direkt



        ar = arPrefab.GetComponent<AssaultRifle>();
        shotgun = shotgunPrefab.GetComponent<Shotgun>();
        smg = smgPrefab.GetComponent<SMG>();
        dualPistol = dualPistolPrefab.GetComponent<DualPistol>();

        currentWeapon = (WeaponCore) dualPistol;

    }
    public void EquipWeapon(WeaponCore newWeapon)
    {
        currentWeapon.gameObject.SetActive(false);
       
        // Set the new weapon as the current weapon
        currentWeapon = newWeapon;

        // Enable the new weapon

         currentWeapon.gameObject.SetActive(true);
         Debug.Log($"Equipped {currentWeapon.weaponData.weaponName}");
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))

        {
            if (currentWeapon.weaponData.currentAmmo > 0)
            {
                audioSource.clip = shootSound;
                audioSource.Play();

                currentWeapon.Shoot();
            }
            else
            {
                Debug.Log("Du har slut på ammunition! Ladda om!");
            }
        }       
    
   if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            EquipWeapon(ar);
        }
   if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(shotgun);
        }
   if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(smg);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipWeapon(dualPistol);
        }


    }
}


