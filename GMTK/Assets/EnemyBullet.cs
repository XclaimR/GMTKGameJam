using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    float bulletLifeTime = 5f;
    [SerializeField]
    float shotgunLifeTime = 0.05f;
    [SerializeField]
    float bulletDamage = 0.5f;
    [SerializeField]
    float shotgunDamage = 0.2f;

    private void Start()
    {
        if(gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject, bulletLifeTime);
        }
        if (gameObject.tag == "ShotgunBullet")
        {
            Destroy(gameObject, shotgunLifeTime);
        }
    }
}
