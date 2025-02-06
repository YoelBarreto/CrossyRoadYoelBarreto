using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] Farmers;
    public Transform[] roads;

    private float[] spawnIntervals = {0.8f, 0.7f, 0.6f}; // Intervalos de tiempo
    private float spawn = 85f;  // Posiciones máximas Z para cada carretera

    private float[][] lanePositions = 
    {
        // Carriles de la carretera
        new float[] { -5f, 4.5f },
        new float[] { 25f, 34.5f },
        new float[] { 55f, 64.5f }
    };

    void Start()
    {
        for (int i = 0; i < roads.Length; i++)
        {
            StartCoroutine(SpawnAnimalsCoroutine(i, spawnIntervals[i]));
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private IEnumerator SpawnAnimalsCoroutine(int roadIndex, float interval)
    {
        float startDelay = Random.Range(0f, interval);
        yield return new WaitForSeconds(startDelay);

        if (gameManager.isGameActive) {
            while (true)
            {
                // Elegir una posición X aleatoria entre los carriles de la carretera correspondiente (Derecha/Izquierda)
                float spawnPosX = lanePositions[roadIndex][Random.Range(0, lanePositions[roadIndex].Length)];
                Vector3 spawnPos = new Vector3(spawnPosX, 0, spawn);
                int animalIndex = Random.Range(0, Farmers.Length);
                Instantiate(Farmers[animalIndex], spawnPos, Farmers[animalIndex].transform.rotation);

                // Esperar antes de hacer el siguiente spawn
                yield return new WaitForSeconds(interval);  // Espera según el intervalo definido
            }
        }
    }
}
