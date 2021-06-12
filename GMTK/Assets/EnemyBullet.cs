using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float lifeTime = 5f;
    [SerializeField]
    float bulletDamage = 0.5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
