using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [NonSerialized] public WeaponCore currentWeapon;
    [NonSerialized] public WeaponData weaponData;
    [SerializeField] GameObject arPrefab;
    [SerializeField] GameObject shotgunPrefab;
    [SerializeField] GameObject smgPrefab;
    [SerializeField] GameObject dualPistolPrefab;

    private WeaponCore ar;
    private WeaponCore shotgun;
    private WeaponCore smg;
    private WeaponCore dualPistol;


    private void Start()
    {
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
        
        currentWeapon.ammoText.text = "Ammo: " + currentWeapon.weaponData.currentAmmo;

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))

        {
            if (currentWeapon.weaponData.currentAmmo > 0)
            {              
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

    public void ReFillAmmo()
    {
        weaponData.currentAmmo += currentWeapon.weaponData.ammoBoxAmount;
        currentWeapon.ammoText.text = "Ammo: " + currentWeapon.weaponData.currentAmmo;
    }
}




