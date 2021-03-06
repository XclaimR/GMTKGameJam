using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegainHealth : MonoBehaviour
{
    Transform shieldPlayer;
    float distance;
    [SerializeField]
    float regenerationDistance = 5f;
    private void Awake()
    {
        shieldPlayer = GameObject.FindGameObjectWithTag("Shield").GetComponent<Transform>();
    }

    void Update()
    {
        distance = GetDistance();
        if(distance > regenerationDistance)
        {
            BondHealth bh = GameObject.Find("Bond").GetComponent<BondHealth>();
            bh.RegainHealth();
        }
    }

    private float GetDistance()
    {
        return Vector2.Distance(shieldPlayer.transform.position, transform.position);
    }
}
