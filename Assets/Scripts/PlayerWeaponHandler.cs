using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class PlayerWeaponHandler : MonoBehaviour
{
    [NonSerialized] public WeaponCore currentWeapon;
    [NonSerialized] public WeaponData weaponData;
    [SerializeField] GameObject arPrefab;
    [SerializeField] GameObject shotgunPrefab;
    [SerializeField] GameObject smgPrefab;
    [SerializeField] GameObject dualPistolPrefab;
    [SerializeField] private Image crosshairImage;
    [SerializeField] private Canvas uiCanvas;

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

        EquipWeapon(dualPistol);

    }
    public void EquipWeapon(WeaponCore newWeapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }

        currentWeapon = newWeapon;
        currentWeapon.gameObject.SetActive(true);

        // Uppdatera crosshair-bilden
        UpdateCrosshair(currentWeapon.weaponData.crosshairSprite);

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

        UpdateCrosshairPositionAndRotation();
    }

    public void ReFillAmmo()
    {
        currentWeapon.weaponData.currentAmmo += currentWeapon.weaponData.ammoBoxAmount;
        currentWeapon.ammoText.text = "Ammo: " + currentWeapon.weaponData.currentAmmo;
    }
    private void UpdateCrosshair(Sprite newCrosshair)
    {
        if (crosshairImage != null && newCrosshair != null)
        {
            crosshairImage.sprite = newCrosshair;
        }
    }
    private void UpdateCrosshairPositionAndRotation()
    {
        // Hämta musens position i skärmpixlar
        Vector2 mousePosition = Input.mousePosition;

        // Översätt skärmpixelkoordinater till canvasposition
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiCanvas.GetComponent<RectTransform>(),
            mousePosition,
            uiCanvas.worldCamera,
            out Vector2 canvasPosition);

        // Uppdatera crosshair-position
        crosshairImage.rectTransform.anchoredPosition = canvasPosition;

        // Beräkna rotation baserat på musens riktning från spelaren
        Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = mousePosition - (Vector2)playerPosition;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotera crosshair
        crosshairImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
}




