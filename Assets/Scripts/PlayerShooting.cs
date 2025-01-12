using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour, PlayerShooting.IShootable
{
    public interface IShootable
    {
        void Shoot(Transform firePoint, float bulletForce);
    }

    public CameraFollow cameraShake;
    public Animator animator;


    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] private float bulletForce;
    [SerializeField] private float fireRate;

    float sprayAngle = 4f;

    private float nextTimeToShoot = 0f;

 

    void Update()
    {
        if(animator != null)
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToShoot)
            {
                Shoot(firePoint, bulletForce);           
                nextTimeToShoot = Time.time + fireRate;
            }    
        } 
    }

    public void Shoot(Transform firePoint, float bulletForce)
    {
        float randomAngle = Random.Range(-sprayAngle, sprayAngle);
        Quaternion sprayRotation = Quaternion.Euler(0,0,randomAngle);

        Vector3 bulletDirection = sprayRotation * firePoint.up;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Spawns the bullet at the firepoints position and rotates it 90 degrees
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //Add a force to the bullet

        animator.SetTrigger("Shooting");
       cameraShake.TriggerShake(.1f, .3f);
    }



}