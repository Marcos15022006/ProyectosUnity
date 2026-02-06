using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Velocidad de caída de la nave enemiga
    [SerializeField] float speed;

    [SerializeField] GameObject explosionPrefab;

    // Altura a la que se destruirá la nave enemiga
    const float DESTROY_HEIGHT = -6f;

    void Update()
    {
        // Movimiento hacia abajo
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destruir la nave enemiga cuando alcanza la altura de destrucción
        if (transform.position.y < DESTROY_HEIGHT)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Solo destruir si es disparado (el ShootController ya maneja la puntuación)
        if (other.CompareTag("shoot"))
        {
            Destroy(gameObject);
        }
    }

    void DestroyEnemy()
    {
        // Instanciar la animación de la explosión en la posición de la nave enemiga
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // Destruir la nave enemiga
        Destroy(gameObject);
    }
  
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Colisión con el jugador - no suma puntos
        DestroyEnemy();
    }
}
