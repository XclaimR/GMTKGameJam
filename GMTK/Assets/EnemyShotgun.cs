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
    float fireRate;

    private float nextFire = 0f;
    private bool isFire = false;
    bool readyToFire = false;
    Camera cam;
    private void Awake()
    {
        cam = UnityEngine.Camera.main;
    }
    private void Update()
    {
        readyToFire = false;
        Vector3 viewPos = cam.WorldToViewportPoint(gameObject.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            readyToFire = true;
        }
        if (Time.time >= nextFire)
        {
            isFire = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFire && readyToFire)
        {  Fire();
            
        }
    }
    private void Fire()
    {
        isFire = false;
        nextFire = Time.time + fireRate;
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("ShotgunSpawn");
        for (int i = 0; i < spawns.Length; i++)
        {
            GameObject instantiateBullet = Instantiate(shotgunBullet, spawns[i].transform.position, spawns[i].transform.rotation);
            Rigidbody2D bulletRigidbody = instantiateBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(spawns[i].transform.up * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        //transform.position += -transform.up * Time.deltaTime * 2;
    }
}
