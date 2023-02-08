using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject[] powerUpPrefabs;
    [SerializeField]

    void Start()
    {

        float spawnDelay = Random.Range(1, 2);
        float spawnInterval = Random.Range(1, 2);
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnPowerUp", spawnDelay, Random.Range(7, 12));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy ()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8, 8), 7, 0);

        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
    }
    void SpawnPowerUp()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8, 8), 7, 0);
        int powerIndex = Random.Range(0, powerUpPrefabs.Length);

        Instantiate(powerUpPrefabs[powerIndex], spawnPos, powerUpPrefabs[powerIndex].transform.rotation);
    }
}
