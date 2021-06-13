using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField]
    float speed;
    Transform bond;
    Rigidbody2D enemyRigidbody;
    [SerializeField]
    float range;
    float distance;
    private float ang = 0;
    private Quaternion qTo;
    private float rotationSpeed = 10.0f;
    float LorR;
    Vector2 finalDirection;
    bool enter = false;
    // Start is called before the first frame update
    void Start()
    {
        LorR = Random.Range(1, 10);
        bond = GameObject.Find("MidPoint").GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    private void Update()
    {
        distance = GetDistance();
        
        if (distance > range)
        {
            Vector2 direction = new Vector2(bond.position.x, bond.position.y) - enemyRigidbody.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            enemyRigidbody.rotation = angle;
            transform.position += transform.up * Time.deltaTime * speed;
        }
        else
        {
            transform.position += transform.up * Time.deltaTime * speed * 2;

        }
    }

    float GetDistance()
    {
        return Vector2.Distance(bond.transform.position, transform.position);
    }
}
