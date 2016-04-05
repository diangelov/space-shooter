using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

    #region Events

    // OnTriggerExit is called when the Collider has stopped touching the trigger.
    public void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

    #endregion

}