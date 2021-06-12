using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Bond : MonoBehaviour
{
    [SerializeField]
    GameObject shieldPlayer = default;
    [SerializeField]
    GameObject shootPlayer = default;
    LineRenderer line;
    bool isHit = false;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Diffuse"));
        line.SetColors(Color.black, Color.black);
    }


    void Update()
    {
        line.SetPosition(0, shootPlayer.transform.position);
        line.SetPosition(1, shieldPlayer.transform.position);
        RaycastHit2D hit = Physics2D.Linecast(shootPlayer.transform.position, shieldPlayer.transform.position, 1 << LayerMask.NameToLayer("Enemy"));
        if (hit.collider != null && !isHit)
        {
            isHit = true;
            BondHealth bh = GameObject.Find("Bond").GetComponent<BondHealth>();
            if (hit.collider.gameObject.tag == "EnemyBullet")
            {
                bh.LoseHealth();
                if (bh.ReturnHealth() <= 0)
                {
                    Debug.Log("Dead");
                }
            }
            if(hit.collider.gameObject.tag == "Enemy")
            {
                bh.isDead = true;
                Debug.Log("Game Over");
            }
            Destroy(hit.collider.gameObject);

            isHit = false;

        }
    }
}
