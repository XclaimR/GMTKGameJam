using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
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
    private float rotationSpeed;
    float LorR;
    Vector2 finalDirection;
    bool enter = false;
    bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = speed;
        range = Random.Range(4f, 5f);
        LorR = Random.Range(1, 10);
        bond = GameObject.Find("MidPoint").GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        distance = GetDistance();
        Vector2 direction = new Vector2(bond.position.x,bond.position.y) - enemyRigidbody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyRigidbody.rotation = angle;
        if (distance > range || firstTime == true)
        {
            transform.position += transform.up * Time.deltaTime * speed;
            firstTime = false;
        }
        else
        {
            if (!enter)
            {
                finalDirection = direction;
                enter = true;
            }
            ang = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
            qTo = Quaternion.AngleAxis(ang, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotationSpeed * Time.deltaTime);
            if (LorR <= 5)
            {
                ang = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
                qTo = Quaternion.AngleAxis(ang, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.right * speed * Time.deltaTime);

            }
            else
            {
                ang = Mathf.Atan2(finalDirection.y, finalDirection.x) * Mathf.Rad2Deg;
                qTo = Quaternion.AngleAxis(ang, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotationSpeed * Time.deltaTime);
                transform.Translate(-Vector3.left * speed * Time.deltaTime);
            }
        }
    }


    float GetDistance()
    {
        return Vector2.Distance(bond.transform.position, transform.position);
    }
}
