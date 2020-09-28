using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehavior : MonoBehaviour
{

    public GameObject nextLink;
    public GameObject snakeHead;
    public GameObject snakeTail;
    public float spd;
    public int mvDirection;

    public GameObject bodyPrefab;
    public Vector3 oldPos;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (snakeHead == nextLink)
        {
            mvDirection = nextLink.GetComponent<Snake>().moveDirection;
            spd = nextLink.GetComponent<Snake>().speed;
        }
        else
        {
            mvDirection = nextLink.GetComponent<BodyBehavior>().mvDirection;
            spd = nextLink.GetComponent<BodyBehavior>().spd;
        }
       // Move();
    }


    public GameObject FindTail()
    {
        if (this.gameObject == this.snakeTail)
            return this.gameObject;
        else
            return snakeTail.GetComponent<BodyBehavior>().FindTail();
    }

    public void Move()
    {

        //if (mvDirection == 0)
        //{
        //    oldPos = new Vector3(transform.position.x - spd, transform.position.y);
        //}
        //if(mvDirection == 1)
        //{
        //    oldPos = new Vector3(transform.position.x, transform.position.y + spd);
        //}
        //if(mvDirection == 2)
        //{
        //    oldPos = new Vector3(transform.position.x + spd, transform.position.y);
        //}
        //if(mvDirection == 3)
        //{
        //    oldPos = new Vector3(transform.position.x, transform.position.y - spd);
        //}


        if (nextLink != snakeHead)
            nextLink.GetComponent<BodyBehavior>().Move();
        oldPos = transform.position;

        if(snakeHead == nextLink)
            transform.position = nextLink.GetComponent<Snake>().oldPosition;
        else
            transform.position = nextLink.GetComponent<BodyBehavior>().oldPos;
    }

    public void Grow()
    {
        if (nextLink != snakeHead)
        {
            GameObject spwner = nextLink.GetComponent<BodyBehavior>().spawner;
            GameObject newBody = Instantiate(bodyPrefab, spwner.transform);

            newBody.transform.position = oldPos;
            newBody.GetComponent<BodyBehavior>().bodyPrefab = bodyPrefab;
            newBody.GetComponent<BodyBehavior>().nextLink = snakeTail;
            newBody.GetComponent<BodyBehavior>().snakeHead = snakeHead;
            newBody.GetComponent<BodyBehavior>().snakeTail = newBody;
            newBody.GetComponent<BodyBehavior>().spawner = spwner;
            snakeTail = newBody;
        }
        else
        {
            GameObject newBody = Instantiate(bodyPrefab, spawner.transform);

            newBody.transform.position = oldPos;
            newBody.GetComponent<BodyBehavior>().bodyPrefab = bodyPrefab;
            newBody.GetComponent<BodyBehavior>().nextLink = snakeTail;
            newBody.GetComponent<BodyBehavior>().snakeHead = snakeHead;
            newBody.GetComponent<BodyBehavior>().snakeTail = newBody;
            newBody.GetComponent<BodyBehavior>().spawner = spawner;
            snakeTail = newBody;
        }
    }


}
