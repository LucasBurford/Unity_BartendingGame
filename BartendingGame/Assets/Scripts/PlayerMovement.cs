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
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    private Vector3 movement;

    #endregion

    // Start is called once per frame
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove);
    }
}
