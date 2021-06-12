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

    private float halfPlayerSizeX;
    private float halfPlayerSizeY;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        halfPlayerSizeX = GetComponent<BoxCollider2D>().size.x / 3;
        halfPlayerSizeY = GetComponent<BoxCollider2D>().size.y / 3;

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

        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        clampPlayerMovement();
    }

    private void clampPlayerMovement()
    {
        Vector3 position = transform.position;

        float distance = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + halfPlayerSizeX;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - halfPlayerSizeX;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y + halfPlayerSizeY;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y - halfPlayerSizeY;

        position.x = Mathf.Clamp(position.x, leftBorder, rightBorder);
        position.y = Mathf.Clamp(position.y, topBorder, bottomBorder);
        transform.position = position;
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);

        Vector2 direction = mousePosition - playerRigidbody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        playerRigidbody.rotation = angle;
    }
}
