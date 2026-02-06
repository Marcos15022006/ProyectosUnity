using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variable para llevar el control de la puntuación
    public static int Score { get; private set; } = 0;
    public static int Lives { get; private set; } = 8;

    public static int[] totalBricks = new int[] { 0, 32, 21 };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    // Referencia al texto para mostrar la puntuación en la interfaz

    // Método para actualizar la puntuación
    public static void UpdateScore(int points)
    {
        Score += points;
    }

    // Método para actualizar las vidas
    public static void Updatelives()
    {
        Lives--;
    }

    public static void ResetGame()
    {
        Score = 0;

        Lives = 5;

        SceneManager.LoadScene(0);
    }
}
