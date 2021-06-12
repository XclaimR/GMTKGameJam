using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool isFire = false;
    private bool isShield = false;
    private float lastFireTime = 0f;
    private float rateofFire = 8f;
    private float lastShieldTime;
    private float holdShield = 0.75f;
    Vector2 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > lastFireTime)
        {
            isFire = true;
            lastFireTime = Time.time + rateofFire;
        }
        if(lastShieldTime - Time.time < 0)
        {
            transform.localScale = originalScale;
        }
    }

    private void FixedUpdate()
    {
        if (isFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
        transform.localScale = new Vector2(transform.localScale.x * 3f, transform.localScale.y * 3f);
        lastShieldTime = Time.time + holdShield;
        isFire = false;
    }
}
