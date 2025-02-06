using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private float floatAmplitude = 0.5f;
    private float floatSpeed = 2f;
    public int pointValue = 5;
    private Vector3 initialPosition;
    private GameManager gameManager;
    void Start()
    {
        // Guardar la posición inicial de la moneda
        initialPosition = transform.position;

        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí solo destruimos la moneda cuando el jugador la toca
            
            gameManager.UpdateScore(pointValue); 
            Destroy(gameObject);
        }
    }

    public void ResetPosition()
    {
        // Restablecer la posición inicial de la moneda
        transform.position = initialPosition;
    }
}
