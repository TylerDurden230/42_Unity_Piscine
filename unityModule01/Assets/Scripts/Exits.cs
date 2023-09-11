using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exits : MonoBehaviour
{

    public bool isActive = false;
    public string characterName;
    public string exitTag;

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.name == characterName)
            isActive = true;
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.name == characterName)
            isActive = false;
    } 
}
