using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Slider sliderRef;
    public GameObject babyPrefab;
    public int enemPerWave = 5;
    public float timeBetweenWaves = 5f;
    public float timeBetweenSpawns = 2.5f;
    private int waveNum = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        //spawn ftn
        while (true)
        {
            // ramp up
            if(waveNum == 3)
            {
                enemPerWave = 8;
                Debug.Log("Baby dropper Level 2!");
            }
            else if(waveNum == 6)
            {
                enemPerWave = 10;
                Debug.Log("Baby dropper Level 3!");
            }
            else if(waveNum == 10)
            {
                enemPerWave = 13;
                Debug.Log("Baby dropper Maxxed!");
            }
            waveNum++;
            Debug.Log($"spawning wave #{waveNum}");

            for (int i = 0; i < enemPerWave; i++)
            {
                SpawnBaby();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            // waits from wave to wave;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnBaby()
    {
        // spawns based on from the length of the spanwer sprite position
        float leftBound = sliderRef.getXPos() - (0.5f * sliderRef.length());
        float rightBound = sliderRef.getXPos() + (0.5f * sliderRef.length());
        Vector2 spawnPos = new Vector2(Random.Range(leftBound, rightBound), 7f);

        Instantiate(babyPrefab, spawnPos, Quaternion.identity);
    }
}