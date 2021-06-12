using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Transform gun = default;

    [SerializeField]
    GameObject bullet = default;

    [SerializeField]
    float bulletForce = 0;

    [SerializeField]
    float fireRate = 0.3f;

    private bool isFire = false;
    float distance;
    float lastFire;
    GameObject shieldPlayer;
    private void Start()
    {
        shieldPlayer = GameObject.FindGameObjectWithTag("Shield");
        distance = Vector2.Distance(shieldPlayer.transform.position, transform.position);
    }

    private void Update()
    {
        distance = Vector2.Distance(shieldPlayer.transform.position, transform.position);

        if (Input.GetMouseButton(0) && (Time.time - lastFire) > 0)
        {
            isFire = true;
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
        GameObject instantiateBullet = Instantiate(bullet, gun.position, gun.rotation);
        Rigidbody2D bulletRigidbody = instantiateBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(gun.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);
        isFire = false;
        lastFire = Time.time + fireRate / (Mathf.Pow(1.1f,distance));
    }
}
