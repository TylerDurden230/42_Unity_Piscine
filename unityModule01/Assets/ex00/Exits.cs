using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exits : MonoBehaviour
{

    public bool isActive = false;
    public string characterName;
    public string exitTag;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log(collision.gameObject.name + " in Collisione con exit " + characterName);
        if (collision.gameObject.name == characterName)
            isActive = true;
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.name == characterName)
            isActive = false;
    } 
}
