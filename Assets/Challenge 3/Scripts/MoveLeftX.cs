//Gabriela Rosas Castillo 
//GDGS2102
//16-10-2022
//Desarrollo de videojuegos


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed;
    private PlayerControllerX playerControllerScript;
    private float leftBound = -10;

    // Actualización del primer cuadro
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el juego no ha terminado, mover a la izquerda
        if (playerControllerScript.gameOver== false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // Destruir cualquier objeto fuera del fondo
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
