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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,0.6f);
        }
    }
}
