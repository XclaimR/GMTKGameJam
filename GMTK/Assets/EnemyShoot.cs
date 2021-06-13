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
    private float lastFire = 0f;
    private float coolDown = 3f;
    bool readyToFire = false;
    Camera cam;
    AudioSource audio;
    private void Awake()
    {
        cam = UnityEngine.Camera.main;
        audio = GameObject.Find("EnemyShootSound").GetComponent<AudioSource>();
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
        if (Time.time >= lastFire )
        {
            isFire = true;
            lastFire = Time.time + coolDown;
        }
    }

    private void FixedUpdate()
    {

        if (isFire && readyToFire)
        {
            Fire();
        }

    }

    private void Fire()
    {
        audio.Play();
        GameObject instantiateBullet = Instantiate(bullet, gun.position, gun.rotation);
        Rigidbody2D bulletRigidbody = instantiateBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(gun.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);
        isFire = false;
    }
}
