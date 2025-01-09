using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float sprintSpeed;  // New serialized field for sprint speed
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift; // The key to activate sprinting (default is Left Shift)

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
        transform.up = (mousePos - new Vector2(transform.position.x, transform.position.y));
    }

    void FixedUpdate()
    {
        // If the sprint key is held down, multiply the speed by the sprint speed
        float currentMoveSpeed = Input.GetKey(sprintKey) ? sprintSpeed : moveSpeed;

        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}