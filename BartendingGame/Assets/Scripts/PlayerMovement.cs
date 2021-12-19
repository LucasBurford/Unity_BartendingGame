using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [Header("Gameplay and spec")]

    // The move speed of the player
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    #endregion

    // Start is called once per frame
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gather horizontal inputs
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        // Store them in a Vector3
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        // Apply Vector3 to position
        transform.position += moveDirection * moveSpeed;
    }
}
