using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int p1Score;
    int p2Score;
    bool running = false;


    [SerializeField] TMP_Text txtP1Score;
    [SerializeField] TMP_Text txtP2Score;
    [SerializeField] TMP_Text txtGanador;
    [SerializeField] GameObject pelota;

    void Start()
    {
        Cursor.visible = false;
        if (txtGanador != null)
        {
            txtGanador.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (!running && Input.GetKeyDown(KeyCode.Space))
        {
            // Activamos la pelota 
            pelota.SetActive(true);
            // Indicamos que el juego ha comenzado
            running = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddPointP1()
    {
        p1Score++;
        txtP1Score.text = p1Score.ToString();
        if (p1Score >= 10)
        {
            MostrarGanador("¡Jugador 1 ha ganado!");
        }
    }
    public void AddPointP2()
    {
        p2Score++;
        txtP2Score.text = p2Score.ToString();
        if (p2Score >= 10)
        {
            MostrarGanador("¡Jugador 2 ha ganado!");
        }
    }

    void MostrarGanador(string mensaje)
    {
        running = false;
        pelota.SetActive(false);
        
        if (txtGanador != null)
        {
            txtGanador.text = mensaje;
            txtGanador.gameObject.SetActive(true);
        }
        
        StartCoroutine(VolverAMenuPrincipal());
    }

    System.Collections.IEnumerator VolverAMenuPrincipal()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainScene");
    }


}
