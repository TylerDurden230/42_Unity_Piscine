using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.5)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
