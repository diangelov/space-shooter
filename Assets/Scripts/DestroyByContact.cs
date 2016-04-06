using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    #region Properties

    public GameObject explosion;
    public GameObject playerExplosion;

    #endregion

    #region Events

    // OnTriggerEnter is called when the Collider enters the trigger.
    public void OnTriggerEnter(Collider other)
    {
        // Ignore the Boundary events
        if (other.tag.Equals("Boundary"))
        {
            return;
        }

        Destroy(gameObject);
        Destroy(other.gameObject);

        // Run explosion VFXs
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag.Equals("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
    }

    #endregion

}