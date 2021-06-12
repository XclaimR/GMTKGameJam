using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    Transform gun = default;

    [SerializeField]
    GameObject bullet = default;

    [SerializeField]
    float bulletForce = 0;

    private bool isFire = false;
    private float lastFire = 100000f;
    private float coolDown = 3f;


    private void Update()
    {
        if (Time.time >= lastFire)
        {
            isFire = true;
            lastFire = Time.time + coolDown;
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
    }
}
