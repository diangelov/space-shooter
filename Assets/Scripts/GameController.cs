using System.Collections;

using UnityEngine;

public class GameController : MonoBehaviour
{

    #region Properties

    public GameObject hazard;

    public int hazardsInOneSec = 2;
    public int hazardWaveCount = 10;

    public float startWaitInSec = 1f;
    public float waveWaitInSec = 0.8f;

    public Vector3 spawnInitLocation;

    public GUIText scoresText;

    private int scores;

    private float spawnWait;

    #endregion

    #region Events

    // Use this event for initialization.
    void Start()
    {
        UpdateScores();

        // Calculate hazard's spawn wait
        spawnWait = 1f / hazardsInOneSec;

        // Unleash the hazards
        StartCoroutine(SpawnWaves());
    }

    #endregion

    #region Public Methods

    public void AddScore(int scoresToAdd)
    {
        scores += scoresToAdd;

        UpdateScores();
    }

    #endregion

    #region Private Methods

    private IEnumerator SpawnWaves()
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

    private void UpdateScores()
    {
        scoresText.text = "Score: " + scores.ToString();
    }

    #endregion

}