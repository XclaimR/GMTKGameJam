using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float enemyHealth = 2f;
    AudioSource audioSource;
    bool playOnce = false;
    public NewEnemySpawn enemySpawn;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemySpawn = GameObject.Find("GameManager").GetComponent<NewEnemySpawn>();
        enemySpawn.enemyCount++;
    }

    public void LoseHealth(float bulletDamage)
    {
        enemyHealth -= bulletDamage;
        if(enemyHealth <= 0f)
        {
            if (!playOnce)
            {
                audioSource.Play();
                playOnce = true;
            }
            enemySpawn.enemyCount--;
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,0.6f);
        }
    }
}
