using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [Header("References")]
    public Rigidbody rb;

    public CharacterController controller;

    [Header("Gameplay and spec")]

    public Vector3 move;

    // The move speed of the player
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    // Sprinting
    [SerializeField]
    private bool isSprinting;

    // Bool to determine if player can move
    public bool canMove;

    #endregion

    // Start is called once per frame
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        move = movementDirection;

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (canMove)
        {
            controller.Move(move * moveSpeed);

            // rb.velocity = new Vector3(horizontalInput, rb.velocity.y, verticalInput) * moveSpeed;
        }
        else
        {
            print("Can't move");
        }
    }
}
