using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    [SerializeField] Transform head;
    [SerializeField] Transform weapon;
    [SerializeField] float gunFollowSpeed;

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


        Vector2 playerToMouse = mousePos - (Vector2)transform.position;


        Vector2 smoothedDirection = Vector2.Lerp(weapon.up, playerToMouse.normalized, Time.deltaTime * gunFollowSpeed);
        weapon.up = smoothedDirection;
    }

    void FixedUpdate()
    {
        // If the sprint key is held down, multiply the speed by the sprint speed
        float currentMoveSpeed = Input.GetKey(sprintKey) ? sprintSpeed : moveSpeed;

        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}