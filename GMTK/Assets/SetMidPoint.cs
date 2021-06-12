using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMidPoint : MonoBehaviour
{
    Vector2 shootPlayer;
    Vector2 shieldPlayer;
    private void Awake()
    {
        shootPlayer = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Transform>().position;
        shieldPlayer = GameObject.FindGameObjectWithTag("Shield").GetComponent<Transform>().position;
        Debug.Log(shootPlayer + "       " + shieldPlayer);
    }
    void Update()
    {
        shootPlayer = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Transform>().position;
        shieldPlayer = GameObject.FindGameObjectWithTag("Shield").GetComponent<Transform>().position;
        transform.position = new Vector2((shootPlayer.x + shieldPlayer.x) / 2, (shootPlayer.y + shieldPlayer.y) / 2);
    }
}
