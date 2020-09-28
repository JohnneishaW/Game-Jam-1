using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethCollision : MonoBehaviour
{

    public GameObject snek;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "body")
        {
            
            Debug.Log("Snake Dies!");
            Application.Quit();             //Snake bites itself and dies, this should bring up end game scene
            Destroy(snek);
        }
    }
}
