using UnityEngine;

public class ShootController : MonoBehaviour
{
    // Velocidad de los disparos
    [SerializeField] float speed;

    [SerializeField] GameObject hit;

    // Tiempo que duran los disparos antes de autodestruirse
    [SerializeField] float lifetime;

    void Start()
    {
        // Destruir el disparo después de un cierto tiempo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mover el disparo hacia arriba
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Método para destruir el disparo cuando sale de la pantalla
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Instantiate(hit, transform.position, Quaternion.identity);
            
            // Actualizar puntuación cuando destruimos una nave enemiga
            GameManager gm = GameManager.GetInstance();
            if (gm != null)
            {
                gm.UpdateScore(gm.GetEnemyPoints());
            }

            Destroy(other.gameObject);

            Destroy(gameObject);
        }
        if ( other.CompareTag("AsteroidBig"))
        {
            Instantiate(hit, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
