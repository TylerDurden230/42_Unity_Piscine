using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 20f;
    public bool isControlEnabled = false;

    private Rigidbody rb;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isControlEnabled)
        {
            float moveHorizontal = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
            Vector3 movement = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, 0);
            movement.y = rb.velocity.y;
            rb.velocity = movement;

            // Salto, che può essere effettuato solo quando il personaggio è a terra.
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    // Questo metodo viene chiamato automaticamente da Unity quando il personaggio entra in collisione con un altro oggetto. In questo caso il ground.
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Character"))
        {
            isGrounded = true;
        }
    }
}