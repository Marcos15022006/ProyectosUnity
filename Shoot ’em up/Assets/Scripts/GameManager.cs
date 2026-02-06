using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    const int LIVES = 3;
    const int MAX_LIVES = 4; // Máximo de vidas permitidas (3 iniciales + 1 extra)
    const int ENEMY_POINTS = 100; // Puntos por destruir una nave enemiga
    const int EXTRA_LIFE_SCORE = 5000; // Puntuación necesaria para obtener vida extra
    
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtMaxScore; 
    [SerializeField] GameObject txtMessage; // GameObject que contiene el texto de Game Over
    //Array paara las imágenes que marcan las vidas 
    [SerializeField] GameObject[] imgLives;
 
    int score;
    int maxScore; 
    //Inicializamos las vidas a la constante 
    int lives = LIVES;
    // Variable para rastrear la última puntuación en la que se otorgó una vida extra 
    int lastExtraLifeScore = 0;
    bool gameOver = false;

    static GameManager instance; 

    void Start()
    {
        // Ocultar el mensaje de Game Over al iniciar
        if (txtMessage != null)
        {
            txtMessage.SetActive(false);
        }
    }

    private void OnGUI() {
       for(int i=0; i<imgLives.Length; i++){
            imgLives[i].SetActive(i<lives); 
        }
        txtScore.text = string.Format("{0,4:D4}", score);
    } 

    // Método estático para obtener la instancia del GameManager
    public static GameManager GetInstance()
    {
        return instance;
    }

    // Función Awake se ejecuta cuando se instancia el objeto
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evitar que el objeto se destruya al cambiar de escena
        }
        else if (instance != this)
        {
            // Si ya existe una instancia, destruimos el nuevo GameManager para mantener la singularidad
            Destroy(gameObject);
        }
    }

    // Método para actualizar la puntuación cuando se destruye una nave enemiga
    public void UpdateScore(int points)
    {
        score += points;
        
        // Comprobar si se ha alcanzado el umbral para una vida extra
        CheckExtraLife();
    }

    // Método para comprobar y otorgar vida extra al alcanzar la puntuación requerida
    void CheckExtraLife()
    {
        // Solo otorgar vida extra si no hemos alcanzado el máximo
        if (lives >= MAX_LIVES)
        {
            return;
        }
        
        // Calcular cuántas vidas extra deberían haberse otorgado según la puntuación actual
        int extraLivesEarned = score / EXTRA_LIFE_SCORE;
        int lastExtraLives = lastExtraLifeScore / EXTRA_LIFE_SCORE;
        
        // Si hemos ganado una nueva vida extra y no hemos alcanzado el máximo
        if (extraLivesEarned > lastExtraLives && lives < MAX_LIVES)
        {
            lives++;
            lastExtraLifeScore = score;
            
            // Mostrar mensaje de vida extra temporalmente
            ShowExtraLifeMessage();
        }
    }

    // Método para mostrar mensaje de vida extra (puedes implementarlo con otro TextMeshPro si lo deseas)
    void ShowExtraLifeMessage()
    {
        // Puedes agregar aquí lógica para mostrar un mensaje de "¡VIDA EXTRA!" si tienes otro GameObject para ello
        Debug.Log("¡VIDA EXTRA!");
    }

    // Método para reducir vidas cuando la nave explota
    public void LoseLife()
    {
        lives--;
        
        // Verificar si el juego ha terminado
        if (lives <= 0)
        {
            gameOver = true;
            lives = 0; // Asegurar que no sea negativo
            
            // Mostrar el mensaje de Game Over
            if (txtMessage != null)
            {
                txtMessage.SetActive(true);
            }
        }
    }

    // Método para verificar si el juego ha terminado
    public bool IsGameOver()
    {
        return gameOver;
    }

    // Método público para obtener los puntos de un enemigo
    public int GetEnemyPoints()
    {
        return ENEMY_POINTS;
    }

}
