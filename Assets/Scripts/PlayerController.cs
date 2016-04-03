using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Properties

    public float speed, tilt;
    public Boundary boundary;

    private Rigidbody rb;

    #endregion

    #region Events

    // Use this event for initialization.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called just before performing any physics calculations.
    void FixedUpdate()
    {
        // Move the ship...
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.velocity = movement * speed;

        // ... and constrain it to the game view
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        // Then, tilt the ship while moving left and right
        rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);
    }

    #endregion

}