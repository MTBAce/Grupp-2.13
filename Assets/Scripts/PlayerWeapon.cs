using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private WeaponCore currentWeapon;
    [SerializeField] GameObject arPrefab;
    [SerializeField] GameObject shotGunPrefab;

    private WeaponCore ar;
    private WeaponCore shotGun;


    private void Start()
    {
        ar = arPrefab.GetComponent<AssaultRifle>();
        shotGun = shotGunPrefab.GetComponent<Shotgun>();

        currentWeapon = (WeaponCore) shotGun;
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
            currentWeapon.Shoot();

        }
    
   if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            EquipWeapon(ar);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(shotGun);
        }

    }
}


