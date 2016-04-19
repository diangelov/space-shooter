using UnityEngine;

public class DestroyByTime : MonoBehaviour
{

    #region Properties

    public float lifetime;

    #endregion

    #region Events

    // Use this event for initialization
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    #endregion

}