using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    [SerializeField] Transform head;
    [SerializeField] Transform weapon;
    [SerializeField] float gunFollowSpeed;

    public Image StaminaBar;
    public float Stamina, Maxstamina;
    public float RunCost;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Makes sure the character moves at the same speed diagonally

        LookAtMouse();
    }

    private void LookAtMouse() // Gets the mouse position and rotates the character towards it
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 headDirection = mousePos - (Vector2)head.position;
        head.up = headDirection;

        weapon.position = head.position;


        Vector2 playerToMouse = mousePos - (Vector2)transform.position;

        Vector2 smoothedDirection = Vector2.Lerp(weapon.up.normalized, playerToMouse.normalized, Time.deltaTime * gunFollowSpeed);
        weapon.up = smoothedDirection;
    }

    void FixedUpdate()
    {
        // If the sprint key is held down and the player is moving, multiply the speed by the sprint speed
        bool isSprinting = Input.GetKey(sprintKey) && movement.magnitude > 0 && Stamina > 0;

        float currentMoveSpeed = isSprinting ? sprintSpeed : moveSpeed;

        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);

        // Reduce stamina only when sprinting
       if (StaminaBar != null)
        {
            if (isSprinting)
            {
                Stamina -= RunCost * Time.deltaTime;
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