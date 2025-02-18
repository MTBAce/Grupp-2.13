using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;
    PlayerWeaponHandler playerWeaponHandler;
    PlayerHealth playerHealth;

    [SerializeField] Transform head;
    [SerializeField] Transform gun;
    [SerializeField] float gunFollowSpeed;


    public Image StaminaBar;
    public float Stamina, Maxstamina;
    public float RunCost;
    public float SpeedMultiplier = 1;
    public float runCostMultiplier = 1;

    Vector2 movement;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerWeaponHandler = GetComponent<PlayerWeaponHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Makes sure the character moves at the same speed diagonally
       
    }

    private void LookAtMouse() // Gets the mouse position and rotates the character towards it
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Rotate the head instantly to look at the mouse
        Vector2 headDirection = mousePos - (Vector2)head.position;
        head.up = headDirection;

        // Rotate the gun smoothly towards the mouse position
        Vector2 gunDirection = mousePos - (Vector2)gun.position;
        Vector2 smoothedDirection = Vector2.Lerp(gun.up, gunDirection.normalized, Time.deltaTime * playerWeaponHandler.currentWeapon.weaponData.gunFollowSpeed);
        gun.up = smoothedDirection;
    }

    void FixedUpdate()
    {
        if (!playerHealth.playerDead)
        {
            LookAtMouse();
            // If the sprint key is held down and the player is moving, multiply the speed by the sprint speed
            bool isSprinting = Input.GetKey(sprintKey) && movement.magnitude > 0 && Stamina > 0.5f;


            float currentMoveSpeed = isSprinting ? playerWeaponHandler.currentWeapon.weaponData.sprintSpeed : playerWeaponHandler.currentWeapon.weaponData.moveSpeed;

            rb.MovePosition(rb.position + movement * currentMoveSpeed * SpeedMultiplier * Time.fixedDeltaTime);

            // Reduce stamina only when sprinting
            if (StaminaBar != null)
            {
                if (isSprinting)
                {
                    float baseRunCost = playerWeaponHandler.currentWeapon.weaponData.runCost;
                    Stamina -= baseRunCost * runCostMultiplier * Time.deltaTime;
                    if (Stamina < 0) Stamina = 0; // Prevent stamina from going negative
                }
                else
                {
                    // Optionally regenerate stamina when not sprinting
                    if (Stamina < Maxstamina)
                    {
                        Stamina += (RunCost / 2) * Time.deltaTime; // Half the RunCost as regeneration rate
                        if (Stamina > Maxstamina) Stamina = Maxstamina; // Cap stamina at max
                    }
                }

                // Update stamina bar
                StaminaBar.fillAmount = Stamina / Maxstamina;
            }

        }

    }

    public void ApplyMobilityBoost()
    {      
        Debug.Log("Mobility powerup");
        SpeedMultiplier = 1.2f;
        runCostMultiplier = 0.4f;
    }

}