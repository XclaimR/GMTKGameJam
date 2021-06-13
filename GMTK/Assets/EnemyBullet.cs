using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    float bulletLifeTime;
    [SerializeField]
    float shotgunLifeTime;
    [SerializeField]
    public float bulletDamage = 0.5f;
    [SerializeField]
    public float shotgunDamage = 0.2f;

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

    public float DoDamage(GameObject bullet)
    {
        if(bullet.name.Contains("EnemyBullet"))
        {
            return bulletDamage;
        }
        if (bullet.name.Contains("ShotgunBullet"))
        {
            return shotgunDamage;
        }
        return 0;
    }

}
