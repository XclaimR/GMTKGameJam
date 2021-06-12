using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotgun : MonoBehaviour
{
    [SerializeField]
    Transform gun = default;
    [SerializeField]
    GameObject shotgunBullet;
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    int bulletCount = 3;
    [SerializeField]
    float spreadFactor;
    [SerializeField]
    float fireRate;
    public float ConeSize;


    private float nextFire = 0f;
    private bool isFire = false;

    private void Update()
    {
        if (Time.time >= nextFire)
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
        isFire = false;
        nextFire = Time.time + fireRate;
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("ShotgunSpawn");
        for (int i = 0; i < spawns.Length; i++)
        {
            //var randomNumberX = Random.Range(-1, 1);
            //var randomNumberY = Random.Range(-1, 1);
            //var randomNumberZ = Random.Range(-10, 10);
            //var bullet = Instantiate(shotgunBullet, gun.position, gun.rotation);
            //bullet.transform.Rotate(-1, randomNumberY, randomNumberZ);
            //bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward);

            //float xSpread = Random.Range(-1, 1);
            //float ySpread = Random.Range(-1, 1);
            ////normalize the spread vector to keep it conical
            //Vector3 spread = new Vector3(xSpread, ySpread, 0.0f).normalized * ConeSize;
            //Quaternion rotation = Quaternion.Euler(spread) * transform.rotation;
            //var bullet = (GameObject)Instantiate(shotgunBullet, transform.position, rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed + transform.right * xSpread + transform.up * ySpread);
            GameObject instantiateBullet = Instantiate(shotgunBullet, spawns[i].transform.position, spawns[i].transform.rotation);
            Rigidbody2D bulletRigidbody = instantiateBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(spawns[i].transform.up * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
