using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifeTime = 5f;
    [SerializeField]
    float bulletDamage = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth eh = collision.gameObject.GetComponent<EnemyHealth>();
            eh.LoseHealth(bulletDamage);
            Destroy(gameObject);

        }

    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
