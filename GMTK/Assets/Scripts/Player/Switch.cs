using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    [SerializeField]
    GameObject shieldPlayer = default;
    Vector3 shieldPosition;
    bool Transformanim = false;
    AudioSource audio;

    private void Start()
    {
        audio = GameObject.Find("SwitchSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        shieldPosition = shieldPlayer.GetComponent<Transform>().position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
            ObjDisable();
            Animator anim = GetComponent<Animator>();
            Animator anim1 = shieldPlayer.GetComponent<Animator>();
            Animator anim2 = shieldPlayer.transform.GetChild(0).GetComponent<Animator>();
            anim.SetTrigger("Transform");
            anim1.SetTrigger("Transform");
            anim2.SetTrigger("Transform");
            Invoke("SwitchFunction", 0.7f);
            
        }
    }

    void SwitchFunction()
    {
        Vector3 initialPosition = transform.position;
        transform.position = shieldPosition;
        shieldPlayer.GetComponent<Transform>().position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        ObjEnable();
    }

    private void ObjEnable()
    {
        for (var i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled= true;
        }
        for (var i = 0; i < shieldPlayer.transform.childCount; ++i)
        {
            shieldPlayer.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void ObjDisable()
    {
        for (var i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
        for (var i = 0; i < shieldPlayer.transform.childCount; ++i)
        {
            shieldPlayer.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
