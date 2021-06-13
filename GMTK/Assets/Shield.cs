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
    AudioSource asource;
    AudioSource audio;

    private void Start()
    {
        audio = GameObject.Find("HitShieldSound").GetComponent<AudioSource>();
        asource = GetComponent<AudioSource>();
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Shoot" || collision.gameObject.tag != "Bullet")
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("Dead", true);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            Destroy(collision.gameObject,0.6f);
        }
        audio.Play();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time > lastFireTime)
        {
            asource.Play();
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
