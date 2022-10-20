//Gabriela Rosas Castillo 
//GDGS2102
//16-10-2022
//Desarrollo de videojuegos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    // Se llama al inicio antes de la primera actualización del cuadro.
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn de objetos
    void SpawnObjects ()
    {
        // Establecer la ubicación de generación aleatoria y el índice de objetos 
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // Generar nuevo objeto si el juego sigue activo
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}
