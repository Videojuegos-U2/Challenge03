//Gabriela Rosas Castillo 
//GDGS2102
//16-10-2022
//Desarrollo de videojuegos


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        //Se establece la posición
        startPos = transform.position; 
        // Repetición en la mitad del fondo.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; 
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

 
}


