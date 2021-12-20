using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [Header("References")]
    public Rigidbody rb;

    [Header("Gameplay and spec")]

    // The move speed of the player
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotationSpeed;

    // Sprinting
    [SerializeField]
    private bool isSprinting;

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

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        rb.velocity = new Vector3(horizontalInput, rb.velocity.y, verticalInput) * moveSpeed;
    }
}
