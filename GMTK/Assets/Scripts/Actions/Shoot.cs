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

    private bool isFire = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
    }
}
