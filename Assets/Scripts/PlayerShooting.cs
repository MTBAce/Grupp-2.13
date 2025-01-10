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

    public CameraShake cameraShake;
    public Animator animator;


    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] private float bulletForce;

 

    void Update()
    {
        if(animator != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot(firePoint, bulletForce);
                animator.SetTrigger("Shooting");
            }
        }

       
    }

    public void Shoot(Transform firePoint, float bulletForce)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Spawns the bullet at the firepoints position and rotates it 90 degrees

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //Add a force to the bullet

         cameraShake.ShakeCamera(3f, 0.1f); // Trigger camera shake when the player shoots
     
    }



}