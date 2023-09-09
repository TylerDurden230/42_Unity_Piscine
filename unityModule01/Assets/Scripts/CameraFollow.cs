using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Il personaggio da seguire
    public float smoothSpeed = 5f; // La velocità di transizione della camera
    public float zOffset = 10f; // Distanza desiderata lungo l'asse Z

    private Vector3 initialPosition; // La posizione iniziale della camera
    private Quaternion initialRotation; // La rotazione iniziale della camera

    private void Start()
    {
        // Salva la posizione e la rotazione iniziale della camera
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calcola la nuova posizione della camera basata sulla posizione del personaggio
            Vector3 desiredPosition = target.position - new Vector3(0f, 0f, zOffset);

            // Calcola la nuova posizione della camera con una transizione fluida
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Imposta la posizione della camera alla nuova posizione con distanza costante
            transform.position = smoothedPosition;

            // Mantieni la rotazione iniziale della camera
            transform.rotation = initialRotation;
        }
    }
}
