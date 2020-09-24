using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    public float accelerationTime = 5f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float horzIn = Input.GetAxis("Horizontal");
        float vertIn = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horzIn * speed * Time.deltaTime, vertIn * speed * Time.deltaTime, 0);

    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }
}
