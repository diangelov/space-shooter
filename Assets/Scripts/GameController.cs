using UnityEngine;

public class GameController : MonoBehaviour
{

    #region Properties

    public GameObject hazard;
    public Vector3 spawnInitLocation;

    #endregion

    #region Events

    // Use this event for initialization.
    void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnInitLocation.x, spawnInitLocation.x),
            spawnInitLocation.y, spawnInitLocation.z);

        // No rotation
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(hazard, spawnPosition, spawnRotation);
    }

    #endregion

}