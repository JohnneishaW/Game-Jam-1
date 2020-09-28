using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBottom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(temp.x/2, 0 - temp.y ,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
