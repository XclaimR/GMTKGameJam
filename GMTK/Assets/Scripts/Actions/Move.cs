using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed = 0;

    [SerializeField]
    Camera mainCamera;

    private Rigidbody2D playerRigidbody;
    private float horizontalMove = 0;
    private float verticalMove = 0;
    private Vector2 mousePosition; 

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        Animator animatortop = GameObject.Find("Top").GetComponent<Animator>();
        Animator animatorbottom = GameObject.Find("Bottom").GetComponent<Animator>();

        animatortop.SetFloat("Speed", Mathf.Max(Mathf.Abs(horizontalMove),Mathf.Abs(verticalMove)));
        animatorbottom.SetFloat("Speed", Mathf.Max(Mathf.Abs(horizontalMove), Mathf.Abs(verticalMove)));

        Debug.Log(Mathf.Max(Mathf.Abs(horizontalMove), Mathf.Abs(verticalMove)));
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);

        Vector2 direction = mousePosition - playerRigidbody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        playerRigidbody.rotation = angle;
    }
}
