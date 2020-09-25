using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //public Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    //public float accelerationTime = 5f;
    //public float maxSpeed = 5f;
    //private Vector2 movement;
    [SerializeField] private float speed = 0.05f;
    private bool movingUpDown = false;
    private Vector3 newPosition;
    //Eyes
    public GameObject upRightEye;
    public GameObject downRightEye;
    public GameObject downLeftEye;
    public GameObject upLeftEye;
    //Teeth
    public GameObject rightTeeth1;
    public GameObject rightTeeth2;
    public GameObject downTeeth1;
    public GameObject downTeeth2;
    public GameObject leftTeeth1;
    public GameObject leftTeeth2;
    public GameObject upTeeth1;
    public GameObject upTeeth2;

    // Start is called before the first frame update
    void Start()
    {
        //Start the game moving to the right
        upRightEye.SetActive(true);
        downRightEye.SetActive(true);
        downLeftEye.SetActive(false);
        upLeftEye.SetActive(false);
        rightTeeth1.SetActive(true);
        rightTeeth2.SetActive(true);
        downTeeth1.SetActive(false);
        downTeeth2.SetActive(false);
        leftTeeth1.SetActive(false);
        leftTeeth2.SetActive(false);
        upTeeth1.SetActive(false);
        upTeeth2.SetActive(false);

        //rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        newPosition = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        //movement
        //float horzIn = Input.GetAxis("Horizontal");
        //float vertIn = Input.GetAxis("Vertical");
       // transform.position = transform.position + new Vector3(horzIn * speed * Time.deltaTime, vertIn * speed * Time.deltaTime, 0);

    }


    void Move()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && !movingUpDown)
        {
            //use the right teeth and eyes
            upRightEye.SetActive(false);
            downRightEye.SetActive(true);
            downLeftEye.SetActive(true);
            upLeftEye.SetActive(false);           
            rightTeeth1.SetActive(false);
            rightTeeth2.SetActive(false);
            downTeeth1.SetActive(true);
            downTeeth2.SetActive(true);
            leftTeeth1.SetActive(false);
            leftTeeth2.SetActive(false);
            upTeeth1.SetActive(false);
            upTeeth2.SetActive(false);

            newPosition = new Vector2(0, -speed);
            movingUpDown = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !movingUpDown)
        {
            //use the right teeth and eyes
            upRightEye.SetActive(true);
            downRightEye.SetActive(false);
            downLeftEye.SetActive(false);
            upLeftEye.SetActive(true);
            rightTeeth1.SetActive(false);
            rightTeeth2.SetActive(false);
            downTeeth1.SetActive(false);
            downTeeth2.SetActive(false);
            leftTeeth1.SetActive(false);
            leftTeeth2.SetActive(false);
            upTeeth1.SetActive(true);
            upTeeth2.SetActive(true);

            newPosition = new Vector2(0, speed);
            movingUpDown = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && movingUpDown)
        {
            //use the right teeth and eyes
            upRightEye.SetActive(true);
            downRightEye.SetActive(true);
            downLeftEye.SetActive(false);
            upLeftEye.SetActive(false);
            rightTeeth1.SetActive(true);
            rightTeeth2.SetActive(true);
            downTeeth1.SetActive(false);
            downTeeth2.SetActive(false);
            leftTeeth1.SetActive(false);
            leftTeeth2.SetActive(false);
            upTeeth1.SetActive(false);
            upTeeth2.SetActive(false);

            newPosition = new Vector2(speed, 0);
            movingUpDown = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && movingUpDown)
        {
            //use the right teeth and eyes
            upRightEye.SetActive(false);
            downRightEye.SetActive(false);
            downLeftEye.SetActive(true);
            upLeftEye.SetActive(true);
            rightTeeth1.SetActive(false);
            rightTeeth2.SetActive(false);
            downTeeth1.SetActive(false);
            downTeeth2.SetActive(false);
            leftTeeth1.SetActive(true);
            leftTeeth2.SetActive(true);
            upTeeth1.SetActive(false);
            upTeeth2.SetActive(false);

            newPosition = new Vector2(-speed, 0);
            movingUpDown = false;
        }
        transform.position = transform.position + newPosition;
    }


   // void FixedUpdate()
   // {
       // rb.AddForce(movement * maxSpeed);
   // }
}
