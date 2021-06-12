using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    float speed;
    Transform bond;
    Rigidbody2D enemyRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bond = GameObject.Find("MidPoint").GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 direction = new Vector2(bond.position.x,bond.position.y) - enemyRigidbody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        enemyRigidbody.rotation = angle;
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
