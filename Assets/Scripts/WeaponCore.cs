using JetBrains.Annotations;
using UnityEngine;

public  class WeaponCore:MonoBehaviour
{
    public CameraFollow cameraShake;
    public WeaponData weaponData;
    public Transform firePoint;
    public Animator animator;
    [SerializeField] protected GameObject bulletPrefab;

    protected float nextTimeToShoot = 0;
    public virtual void Shoot()
    {
        if (Time.time < nextTimeToShoot) return;

        nextTimeToShoot = Time.time + weaponData.fireRate;

        FireBullet(firePoint, weaponData.spreadAngle, weaponData.pelletCount, weaponData.bulletForce);
        animator.SetTrigger(weaponData.weaponAnimation);
        cameraShake.TriggerShake(weaponData.duration, weaponData.magnitude);
    }

    public virtual void FireBullet(Transform firePoint, float spreadAngle, float pelletCount, float bulletForce)
    {
        for (int i = 0; i < pelletCount; i++)
        {
            float angle = Random.Range(-spreadAngle, spreadAngle); // Chooses a number between -17.5 and 17.5 

            Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, 0, angle);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation); //Instantiates the bullets at the firepoint position, rotating them 90 degrees
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce(rotation * Vector2.up * bulletForce, ForceMode2D.Impulse); //Adds a force to the bullets
        }

    }

}
