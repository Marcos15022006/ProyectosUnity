using UnityEngine;

public class PaController: MonoBehaviour
{
    const float MAX_Y = 4.2f;
    const float MIN_Y = -4.2f;

    [SerializeField] float speed = 10f;

void Update()
{
    if (gameObject.CompareTag("Pa2"))
    {
        if (Input.GetKey("up") && transform.position.y < MAX_Y)
        {
            // Movimiento hacia arriba
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey("down") && transform.position.y > MIN_Y)
        {
            // Movimiento hacia abajo
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    }
    else if (gameObject.CompareTag("Pa1"))
    {
        if (Input.GetKey("w") && transform.position.y < MAX_Y)
        {
            // Movimiento hacia arriba
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey("s") && transform.position.y > MIN_Y)
        {
            // Movimiento hacia abajo
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    }
}
    
}
