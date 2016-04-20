using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    #region Properties

    public int scoreValue;

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

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

        // Run game object explosion VFX
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag.Equals("Player"))
        {
            // Run player explosion VFX
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        else
        {
            InstantiateGameController();

            gameController.AddScore(scoreValue);
        }

        Destroy(gameObject);
        Destroy(other.gameObject);
    }

    #endregion

    #region Private Methods

    private void InstantiateGameController()
    {
        GameObject go = GameObject.FindWithTag("GameController");

        if (go != null)
        {
            gameController = go.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script!");
        }
    }

    #endregion

}