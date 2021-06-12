using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    GameObject[] spawnPoints;
    private BondHealth bondHealth;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject shotgunPrefab;
    [SerializeField]
    GameObject tankPrefab;
    int numEnemies;
    int enemySpawnCount;
    private bool waveCompleted = true;
    int waveCount = 0;
    float timeDelay = 1f;
    float increament = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        bondHealth = GameObject.Find("Bond").GetComponent<BondHealth>();
        numEnemies = 2;
        enemySpawnCount = 0;
        NextWave();

    }
    void Update()
    {
        if (waveCompleted == true && bondHealth.ReturnHealth() > 0)
        {
            Debug.Log("Bond Health " + bondHealth.ReturnHealth());
            waveCount++;
            waveCompleted = false;
            Invoke("NextWave", 2 + waveCount);
        }

    }

    private void NextWave()
    {
        Debug.Log("Next Wave");
        numEnemies = Mathf.RoundToInt(numEnemies * 1.2f);
        enemySpawnCount = 0;
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        List<GameObject> spawns = new List<GameObject>();
        while ((enemySpawnCount <= numEnemies) && !waveCompleted)
        {
            for (int i = 0; i < numEnemies; i++)
            {
                spawns.Add(RandomSpawn());
            }


            foreach (GameObject spawn in spawns)
            {
                float num = UnityEngine.Random.Range(1, 10);
                if(num < 1.5)
                {
                    GameObject enemy = Instantiate(shotgunPrefab, spawn.transform.position, spawn.transform.rotation);

                }
                else if(num >=1.5 && num < 3)
                {
                    GameObject enemy = Instantiate(tankPrefab, spawn.transform.position, spawn.transform.rotation);

                }
                else
                {
                    GameObject enemy = Instantiate(enemyPrefab, spawn.transform.position, spawn.transform.rotation);

                }
                enemySpawnCount++;
            }

            spawns.Clear();


            //Will wait 1 second before spawning a new random object
            yield return new WaitForSeconds(timeDelay);

            if (enemySpawnCount == numEnemies)
            {
                Debug.Log("Wave Completed");
                waveCompleted = true;
                StopCoroutine(spawnEnemies());
            }
        }
        
    }

    GameObject RandomSpawn()
    {
        return spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
    }
    
}
