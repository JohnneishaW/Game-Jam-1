using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    //public Rigidbody2D rb;
    //[SerializeField] private BoxCollider2D bc;
    //public float accelerationTime = 5f;
    //public float maxSpeed = 5f;
    //private Vector2 movement;
    public float speed = 0.01f;
    public int moveDirection = 0;       // 0 = right, 1 = down, 2 = left, 3 = up
    private Vector3 newPosition;
    public Vector3 oldPosition;
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
    private int timeDelay = 20;

    public GameObject rootBody;

    //screen border
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    //apple respawn loc
    int newX = -100;
    int newY = -100;

    //Score
    int score;
    public TMPro.TextMeshProUGUI ScoreText;


    //private int snakeSize;
    // private List<Vector3> snakePosList;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = "Score: " + score;
        //Start the game moving to the right
        rightEye.SetActive(true);
        leftEye.SetActive(false);
        upEye.SetActive(false);
        downEye.SetActive(false);

        rightTeeth.SetActive(true);
        downTeeth.SetActive(false);
        leftTeeth.SetActive(false);
        upTeeth.SetActive(false);

        newPosition = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && moveDirection % 2 == 0)
            moveDirection = 1;
        if (Input.GetKeyDown(KeyCode.UpArrow) && moveDirection % 2 == 0)
            moveDirection = 3;
        if (Input.GetKeyDown(KeyCode.RightArrow) && !(moveDirection % 2 == 0))
            moveDirection = 0;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !(moveDirection % 2 == 0))
            moveDirection = 2;

        //Move every 20 frames
        if (timeDelay <= 0)
        {
            Move();
            timeDelay = 20;
        }
        timeDelay--;    
        //movement
        //float horzIn = Input.GetAxis("Horizontal");
        //float vertIn = Input.GetAxis("Vertical");
       // transform.position = transform.position + new Vector3(horzIn * speed * Time.deltaTime, vertIn * speed * Time.deltaTime, 0);
        

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision!");
        //update player's score
        //Destroy(col.gameObject);    
        /*respawn apple*/
        //if apple's new location is on top of snake or default, generate a new random location
        // while (newX == -100 || newY == -100 || newX == this.gameObject.transform.position.x || newY == this.gameObject.transform.position.y)
        if(col.gameObject.tag == "apple"){
            updateScore();
            Debug.Log("Moving apple");
            newX = (int)Random.Range(borderLeft.position.x + 1f, borderRight.position.x - 1f);
            newY = (int)Random.Range(borderBottom.position.y + 1f, borderTop.position.y - 1f);
            //move apple to new location
            col.gameObject.transform.position = new Vector2(newX, newY);
            GrowSnake();
        }
        else{
            Debug.Log("Snake dies");
            Destroy(this.gameObject);
            Application.Quit();
        }
    }


    void updateScore()
    {
        Debug.Log("Updating score");
        score += 1;
        ScoreText.text = "Score: " + score;
    }

    void GrowSnake()
    {
        rootBody.GetComponent<BodyBehavior>().snakeTail.GetComponent<BodyBehavior>().Grow();
    }

    void Move()
    {
        if(moveDirection == 1)
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

            newPosition = new Vector3(0, -speed);
            moveDirection = 1;

        }
        if (moveDirection == 3)
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

            newPosition = new Vector3(0, speed);
            moveDirection = 3;
        }
        if (moveDirection == 0)
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

            newPosition = new Vector3(speed, 0);
            moveDirection = 0;
        }
        if (moveDirection == 2)
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

            newPosition = new Vector3(-speed, 0);
            moveDirection = 2;
        }
        oldPosition = transform.position;
        transform.position = transform.position + newPosition;

        //snakePosList.Insert(0, transform.position); //not sure if this works, but its supposed to record the head's position everytime it's updated - Henry

       // if (snakePosList.Count >= snakeSize + 1){ //this should cut the list down after the snake is no longer at the position - Henry
        //    snakePosList.RemoveAt(snakePosList.Count - 1);
        //}
    }

    
}
