using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssualtRifle : MonoBehaviour, AssualtRifle.IShootable
{
    public interface IShootable
    {
        void Shoot(Transform firePoint, float bulletForce);
    }

    public Transform firePoint;
    public GameObject bulletPrefab;
    public ScreenShake screenShake;

    Coroutine muzzleFlashCoroutine;

    [SerializeField] private float bulletForce;

    void Awake()
    {
        screenShake = Camera.main.GetComponent<ScreenShake>();
    }

 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(firePoint, bulletForce);
        }
    }

    public void Shoot(Transform firePoint, float bulletForce)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Spawns the bullet at the firepoints position and rotates it 90 degrees

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //Add a force to the bullet

        screenShake.TriggerShake(0.065f, 0.13f);

    }



}