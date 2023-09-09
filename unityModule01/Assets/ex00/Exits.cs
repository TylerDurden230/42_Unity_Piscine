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

    // Update is called once per frame
    void Update()
    {

    }

        private void OnCollisionEnter(Collision collision) 
        {
            // verifica se il personaggio con il nome corrispondente è sulla giusta piattaforma.
            Debug.Log("Collisione con " + collision.gameObject.name);
            Debug.Log("Character name " + characterName);
            if (collision.gameObject.name == characterName)
                isActive = true;
            // altrimenti se non c'è collisione con nessun personaggio, la piattaforma non è attiva.
            else if (collision.gameObject.name != characterName)
                isActive = false;
            else
                isActive = false;
        } 
}
