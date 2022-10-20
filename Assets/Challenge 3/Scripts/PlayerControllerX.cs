//Gabriela Rosas Castillo 
//GDGS2102
//16-10-2022
//Desarrollo de videojuegos


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver=false;
    public float upBound=16;

    public float floatForce;
    private float gravityModifier = 0.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Aplicar fuerza hacia arriba cuando comienza el juego
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // Mientras se presiona el espacio y el jugador está abajo, flota hacia arriba
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        if (transform.position.y > upBound)
        {
           playerRb.AddForce(Vector3.down * 200);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // si el jugador choca con una bomba, explota y se realiza un GameOver
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 200);
        } 

        //si el jugador choca con dinero y obtiene nuevos recursos
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
