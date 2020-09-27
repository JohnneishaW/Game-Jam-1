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
    public GameObject rightEye;
    public GameObject leftEye;
    public GameObject upEye;
    public GameObject downEye;
    //Teeth
    public GameObject rightTeeth;
    public GameObject leftTeeth;
    public GameObject downTeeth;
    public GameObject upTeeth;

    private int snakeSize;
    private List<Vector3> snakePosList;

    // Start is called before the first frame update
    void Start()
    {
        //Start the game moving to the right
        rightEye.SetActive(true);
        leftEye.SetActive(false);
        upEye.SetActive(false);
        downEye.SetActive(false);

        rightTeeth.SetActive(true);
        downTeeth.SetActive(false);
        leftTeeth.SetActive(false);
        upTeeth.SetActive(false);

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
            rightEye.SetActive(false);
            leftEye.SetActive(false);
            upEye.SetActive(false);
            downEye.SetActive(true);  

            rightTeeth.SetActive(false);
            downTeeth.SetActive(true);
            leftTeeth.SetActive(false);
            upTeeth.SetActive(false);

            newPosition = new Vector2(0, -speed);
            movingUpDown = true;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !movingUpDown)
        {
            //use the right teeth and eyes
            rightEye.SetActive(false);
            leftEye.SetActive(false);
            upEye.SetActive(true);
            downEye.SetActive(false);

            rightTeeth.SetActive(false);
            downTeeth.SetActive(false);
            leftTeeth.SetActive(false);
            upTeeth.SetActive(true);

            newPosition = new Vector2(0, speed);
            movingUpDown = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && movingUpDown)
        {
            //use the right teeth and eyes
            rightEye.SetActive(true);
            leftEye.SetActive(false);
            upEye.SetActive(false);
            downEye.SetActive(false);

            rightTeeth.SetActive(true);
            downTeeth.SetActive(false);
            leftTeeth.SetActive(false);
            upTeeth.SetActive(false);

            newPosition = new Vector2(speed, 0);
            movingUpDown = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && movingUpDown)
        {
            //use the right teeth and eyes
            rightEye.SetActive(false);
            leftEye.SetActive(true);
            upEye.SetActive(false);
            downEye.SetActive(false);

            rightTeeth.SetActive(false);
            downTeeth.SetActive(false);
            leftTeeth.SetActive(true);
            upTeeth.SetActive(false);

            newPosition = new Vector2(-speed, 0);
            movingUpDown = false;
        }

        snakePosList.Insert(0, transform.position); //not sure if this works, but its supposed to record the head's position everytime it's updated - Henry


        transform.position = transform.position + newPosition;

        if (snakePosList.Count >= snakeBodySize + 1){ //this should cut the list down after the snake is no longer at the position - Henry
            snakePosList.RemoveAt(snakePosList.Count - 1);
        }
    }


   // void FixedUpdate()
   // {
       // rb.AddForce(movement * maxSpeed);
   // }
}
