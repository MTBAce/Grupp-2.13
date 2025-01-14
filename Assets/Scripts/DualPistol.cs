using UnityEngine;

public class DualPistol : WeaponCore
{
    [SerializeField] private Transform firePoint2;

    private bool useFirstFirePoint = true;

    public override void Shoot()
    {
        if (Time.time < nextTimeToShoot) return;

        nextTimeToShoot = Time.time + weaponData.fireRate;

        if (useFirstFirePoint)
        {
            FireBullet(firePoint, weaponData.spreadAngle, weaponData.pelletCount, weaponData.bulletForce);
        } else
        {
            FireBullet(firePoint2, weaponData.spreadAngle, weaponData.pelletCount, weaponData.bulletForce);
        }  
       
        useFirstFirePoint= !useFirstFirePoint;        

        animator.SetTrigger(weaponData.weaponAnimation);
        cameraShake.TriggerShake(weaponData.duration, weaponData.magnitude);

        audioSource.clip = weaponData.shootSound;
        audioSource.Play();

        if (weaponData.currentAmmo > 0)
        {
            weaponData.currentAmmo--;
            ammoText.text = "Ammo: " + weaponData.currentAmmo;
        }
    }


}
