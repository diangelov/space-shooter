using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    #region Events

    // OnTriggerEnter is called when the Collider enters the trigger.
    public void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Boundary"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    #endregion

}