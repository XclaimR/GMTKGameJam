using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private bool waveCompleted = false;
    int waveCount = 0;
    float timeDelay = 2f;
    float increament = 0.3f;
    GameObject player;
    float timeBetweenWave = 3f;
     List<String> pattern = new List<string>();
    AudioSource audioSource;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("WaveText").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Shoot");
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        bondHealth = GameObject.Find("Bond").GetComponent<BondHealth>();
        numEnemies = 3;
        enemySpawnCount = 0;
        pattern.Add("E");
        pattern.Add("EE");
        pattern.Add("S");
        pattern.Add("ES");
        pattern.Add("EES");
        pattern.Add("W");

        pattern.Add("SS");
        pattern.Add("T");
        pattern.Add("TT");
        pattern.Add("EEE");
        pattern.Add("TPS");
        pattern.Add("TTSS");
        pattern.Add("EEEE");
        pattern.Add("W");

        pattern.Add("TT");
        pattern.Add("TTEE");
        pattern.Add("SSS");
        pattern.Add("EESE");
        pattern.Add("TTT");
        pattern.Add("TTTEE");
        pattern.Add("SSSS");
        pattern.Add("W");

        pattern.Add("TTSS");
        pattern.Add("SSSS");
        pattern.Add("EEEEE");
        pattern.Add("TTSSS");
        pattern.Add("EEEEEE");
        pattern.Add("SSEE");
        pattern.Add("W");

        pattern.Add("TTTTT");
        pattern.Add("SSSPPP");
        pattern.Add("EESSPP");
        pattern.Add("TTTEEE");
        pattern.Add("EEEEEEE");
        pattern.Add("SSSSSS");
        pattern.Add("W");

        pattern.Add("SSSSEEE");
        pattern.Add("EEEEEEE");
        pattern.Add("SSSEEEE");
        pattern.Add("TTTTTE");
        pattern.Add("TTEEEE");
        pattern.Add("SSSSSSS");
        pattern.Add("W");

        pattern.Add("SSSSSSSS");
        pattern.Add("EEEEEEEE");
        pattern.Add("TTTTTT");
        pattern.Add("EEESSSTT");
        pattern.Add("EEEEESS");
        pattern.Add("TTSSSEEE");
        pattern.Add("W");

        pattern.Add("TTTSSSEEE");
        pattern.Add("EEEESSSS");
        pattern.Add("SSSTTTTT");
        pattern.Add("TTTTTTT");
        pattern.Add("TTTTSSSSE");
        pattern.Add("EEEEEEEEE");
        pattern.Add("SSSSSSTT");
        pattern.Add("W");

        pattern.Add("EEEEEEEEEE");
        pattern.Add("TTTTTTSSSS");
        pattern.Add("TTTTEEEESSS");
        pattern.Add("TTEEEEEESSS");
        pattern.Add("TTTTTSSSSS");
        pattern.Add("TTTEEEEEEEE");
        pattern.Add("TTTTTTTT");
        pattern.Add("W");

        pattern.Add("TTTTTTTTTT");
        pattern.Add("SSSSSSSSSSS");
        pattern.Add("TTTTTSSSSSS");
        pattern.Add("TTTTEEEESSSS");
        pattern.Add("TTTTTTSSSSSS");
        pattern.Add("TTTTTEEEEESSS");
        pattern.Add("TTTTTEEEEESSSSS");
        pattern.Add("F");
        NextWave();

    }
    void Update()
    {
        if (waveCompleted == true && bondHealth.ReturnHealth() > 0 && waveCount < 10)
        {
            waveCount++;
            waveCompleted = false;
            if (waveCount > 4)
            {
                Invoke("NextWave", 20f);
                //audioSource.Play();
            }
            else 
            {
                Invoke("NextWave", 10f);
            }
        }

    }

    private void NextWave()
    {
        text.text = ("WAVE " + (waveCount + 1)).ToString();
        Debug.Log("Next Wave");
        numEnemies = Mathf.RoundToInt(numEnemies * 1.5f);
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
                if(num < (1.5 + 0.15*waveCount))
                {
                    GameObject enemy = Instantiate(shotgunPrefab, spawn.transform.position, spawn.transform.rotation);

                }
                else if(num >=(4.5 - 0.15*waveCount) && num < (6 + 0.15 * waveCount))
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
        GameObject spawnpoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        while(GetDistance(spawnpoint) < 8f)
        {
            spawnpoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        }
        return spawnpoint;
    }

    private float GetDistance(GameObject spawn)
    {
        return Vector2.Distance(spawn.transform.position, player.transform.position);
    }
}
