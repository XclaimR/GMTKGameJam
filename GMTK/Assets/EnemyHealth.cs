using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float enemyHealth = 2f;


    public void LoseHealth(float bulletDamage)
    {
        enemyHealth -= bulletDamage;
        if(enemyHealth <= 0f)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            Destroy(gameObject,0.6f);
        }
    }
}
