using UnityEngine;
using System.Collections;

public class PelotaController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force = 0.5f;
    [SerializeField] float delay;

    [SerializeField] AudioClip sfxPaddle;  // Sonido al chocar con la pala
    [SerializeField] AudioClip sfxWall; // Sonido al chocar con una pared
    [SerializeField] AudioClip sfxGoal; // Sonido al meter gol
    [SerializeField] GameManager gameManager;

    const float MIN_ANG = 25.0f;
    const float MAX_ANG = 40.0f;

    // Declaramos dos constantes con las posiciones y máximas y mínimas.
    const float MAX_Y = 2.5f;
    const float MIN_Y = -2.5f;

    AudioSource sfx;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int direccionX = Random.Range(0, 2) == 0 ? -1 : 1;

        StartCoroutine(LanzarPelota(direccionX));
        sfx = GetComponent<AudioSource>();
    }

    IEnumerator LanzarPelota(int direccionX)
    {
        // Definimos el ángulo en radianes usando Range, especificando el mínimo y máximo.
        float angulo = Random.Range(MIN_ANG, MAX_ANG) * Mathf.Deg2Rad;
        float x = Mathf.Cos(angulo) * direccionX;

        // Determinamos si nos movemos hacia la derecha o izquierda.
        // Si el valor devuelto es 0, la dirección en Y será negativa; si es 1, será positiva.
        int direccionY = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Mathf.Sin(angulo) * direccionY;


        Vector2 impulso = new Vector2(x, y);
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(impulso * force, ForceMode2D.Impulse);

        float posY = Random.Range(MIN_Y, MAX_Y);
        transform.position = new Vector3(0, posY, 0);

        yield return new WaitForSeconds(delay);
    }
    // ...

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("Pa1")){
            sfx.clip = sfxPaddle;
            sfx.Play();
        }
        else if (tag.Equals("Pa2")){
            sfx.clip = sfxPaddle;
            sfx.Play();
        }
        else
        {
            sfx.clip = sfxWall;
            sfx.Play();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Gol en " + other.tag + "!!");

        if (other.tag == "PorteriaEsquerda")
        {
            sfx.clip = sfxGoal;
            sfx.Play();
            StartCoroutine(LanzarPelota(1));
            gameManager.AddPointP2();
            // Lanzaremos la pelota hacia la derecha

        }
        else if (other.tag == "PorteriaDereita")
        {
            sfx.clip = sfxGoal;
            sfx.Play();
            StartCoroutine(LanzarPelota(-1));
            gameManager.AddPointP1();
            // Lanzaremos la pelota hacia la izquierda

        }
    }



}
