using UnityEngine;

public class SMG : WeaponCore
{
    [SerializeField] private Transform firePoint2;

    public override void Shoot()
    {
        if (Time.time < nextTimeToShoot) return;

        nextTimeToShoot = Time.time + weaponData.fireRate;

        FireBullet(firePoint, weaponData.spreadAngle, weaponData.pelletCount, weaponData.bulletForce);
        FireBullet(firePoint2, weaponData.spreadAngle, weaponData.pelletCount, weaponData.bulletForce);

        animator.SetTrigger(weaponData.weaponAnimation);
        cameraShake.TriggerShake(weaponData.duration, weaponData.magnitude);

        audioSource.clip = weaponData.shootSound;
        audioSource.Play();

        if (weaponData.currentAmmo > 0)
        {
            weaponData.currentAmmo-=2;
            ammoText.text = "Ammo: " + weaponData.currentAmmo;
        }
    }
}
