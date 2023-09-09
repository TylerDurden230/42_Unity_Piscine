using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1));
            //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0));
            //GetComponent<Rigidbody>().velocity = new Vector3(-1,0,0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1));
            //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0));
            //GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

    }
}