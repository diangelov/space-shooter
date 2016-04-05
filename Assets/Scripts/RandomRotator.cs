using UnityEngine;

public class RandomRotator : MonoBehaviour
{

    #region Properties

    public float maxTumble = 0;

    private Rigidbody rb;

    #endregion

    #region Events

    // Use this event for initialization.
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        rb.angularVelocity = Random.insideUnitSphere * maxTumble;
    }

    #endregion

}