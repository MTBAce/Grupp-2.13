using JetBrains.Annotations;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    PlayerWeaponHandler playerWeaponHandle;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerWeaponHandle = collision.GetComponent<PlayerWeaponHandler>();
            playerWeaponHandle.ReFillAmmo();
          Destroy(gameObject);
        }
    }


}
