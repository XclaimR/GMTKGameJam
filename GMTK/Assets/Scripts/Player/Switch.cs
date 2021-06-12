using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    [SerializeField]
    Transform shieldPlayer = default;
    Transform shootPlayer;
    Vector3 shieldPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        shieldPosition = shieldPlayer.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 initialPosition = transform.position;
            transform.position = shieldPosition;
            shieldPlayer.position = new Vector3(initialPosition.x,initialPosition.y,initialPosition.z);
        }
    }
}
