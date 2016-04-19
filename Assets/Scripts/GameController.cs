using System.Collections;

using UnityEngine;

public class GameController : MonoBehaviour
{

    #region Properties

    public GameObject hazard;
    public Vector3 spawnInitLocation;

    public int hazardWaveCount = 10;
    public int hazardsInOneSec = 2;

    public float startWaitInSec = 1f;
    public float waveWaitInSec = 0.8f;

    private float spawnWait;

    #endregion

    #region Events

    // Use this event for initialization.
    void Start()
    {
        // Calculate hazard's spawn wait
        spawnWait = 1f / hazardsInOneSec;

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        // Wait before the first wave
        yield return new WaitForSeconds(startWaitInSec);

        while (true)
        {
            for (int i = 0; i < hazardWaveCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnInitLocation.x, spawnInitLocation.x),
                    spawnInitLocation.y, spawnInitLocation.z);

                // No rotation
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            // Wait before the next wave
            yield return new WaitForSeconds(waveWaitInSec);
        }
    }

    #endregion

}