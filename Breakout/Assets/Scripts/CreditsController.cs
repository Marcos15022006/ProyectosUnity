using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [SerializeField] float waitTime = 5f;

    void Start()
    {
        // Desactiva el cursor en los créditos también
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        // Espera 5 segundos y luego reinicia el juego
        Invoke("RestartGame", waitTime);
    }

    void Update()
    {
        // Permite salir con ESC durante los créditos
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    void RestartGame()
    {
        GameManager.ResetGame();
    }
}
