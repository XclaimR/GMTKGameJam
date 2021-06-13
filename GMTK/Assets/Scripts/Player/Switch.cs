using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    [SerializeField]
    GameObject shieldPlayer = default;
    Vector3 shieldPosition;
    bool Transformanim = false;

    void Update()
    {
        shieldPosition = shieldPlayer.GetComponent<Transform>().position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Animator anim = GetComponent<Animator>();
            //Animator anim1 = shieldPlayer.GetComponent<Animator>();
            //anim.SetTrigger("Transform");
            //anim1.SetTrigger("Transform");
            Vector3 initialPosition = transform.position;
            transform.position = shieldPosition;
            shieldPlayer.GetComponent<Transform>().position = new Vector3(initialPosition.x,initialPosition.y,initialPosition.z);
        }
    }
}
