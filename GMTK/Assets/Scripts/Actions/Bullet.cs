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
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
            EnemyHealth eh = collision.gameObject.GetComponent<EnemyHealth>();
            eh.LoseHealth(bulletDamage);
            Destroy(gameObject,0.6f);
        }
        if(collision.gameObject.tag == "Shield")
        {
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Dead", true);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            Destroy(gameObject, 0.6f);
        }

    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
