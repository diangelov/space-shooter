using UnityEngine;

public class BoltMove : MonoBehaviour
{

    #region Properties

    public float speed;

    private Rigidbody rb;

    #endregion

    #region Events

    // Use this event for initialization.
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * speed;
    }

    #endregion

}