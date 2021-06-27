using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewEnemySpawn : MonoBehaviour
{
    GameObject[] spawnPoints;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject shotgunPrefab;
    [SerializeField]
    GameObject tankPrefab;
    List<String> pattern = new List<string>();
    float nextSpawnTime;
    bool waveComplete = true;
    int waveCount = 0;
    private BondHealth bondHealth;
    List<GameObject> spawns = new List<GameObject>();
    GameObject player;
    private bool skipWait;
    private bool done = false;
    public int enemyCount = 0;
    float timeDelay = 2f;
    Text text;
    int bigWaveCount = 1;

    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        player = GameObject.FindGameObjectWithTag("Shoot");
        bondHealth = GameObject.Find("Bond").GetComponent<BondHealth>();
        text = GameObject.Find("WaveText").GetComponent<Text>();
        text.text = ("WAVE 1").ToString();

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
    }

    void Update()
    {
        while(waveComplete && bondHealth.ReturnHealth() > 0 && (enemyCount == 0) && !done)
        {
            Debug.Log("Entered Wave");
            
            waveComplete = false;
            StartCoroutine(spawnEnemies());
            waveCount++;
        }  
    }

    IEnumerator spawnEnemies()
    {
        for (int i = 0; i < pattern[waveCount].Length; i++)
        {
            spawns.Add(RandomSpawn());
        }
        int enemyCount = 0;
        foreach (char e in pattern[waveCount])
        {
            
            switch (e)
            {
                case 'E':
                    Instantiate(enemyPrefab, spawns[enemyCount].transform.position, spawns[enemyCount].transform.rotation);

                    break;

                case 'S':
                    Instantiate(shotgunPrefab, spawns[enemyCount].transform.position, spawns[enemyCount].transform.rotation);

                    break;

                case 'T':
                    Instantiate(tankPrefab, spawns[enemyCount].transform.position, spawns[enemyCount].transform.rotation);

                    break;

                case 'W':
                    Debug.Log("Wave Completed");
                    bigWaveCount++;
                    text.text = ("WAVE " + (bigWaveCount)).ToString();
                    yield return new WaitForSeconds(5f);
                    skipWait = true;
                    break;

                case 'F':
                    done = true;
                    break;
            }
            enemyCount++;
        }
        spawns.Clear();
        Debug.Log("Small Wave Completed");
        yield return new WaitForSeconds(timeDelay);

        waveComplete = true;
    }

    void NextWave()
    {
    }

    GameObject RandomSpawn()
    {
        GameObject spawnpoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        while (GetDistance(spawnpoint) < 8f)
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
