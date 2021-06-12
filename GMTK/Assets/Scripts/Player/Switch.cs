using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    [SerializeField]
    Transform shieldPlayer = default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 initialPosition = transform.position;
            transform.position = shieldPlayer.position;
            shieldPlayer.position = initialPosition;
        }
    }
}
