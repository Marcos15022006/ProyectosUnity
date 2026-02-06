using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI txtScore;

    [SerializeField] TextMeshProUGUI txtlives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnGUI()
    {
        // Verificamos que los objetos existan antes de usarlos
        if (txtScore == null || txtlives == null)
            return;
            
        // Actualizar el texto 
        txtScore.text = string.Format("{0,3:D3}", GameManager.Score); // Queremos formatearlo a 3 dígitos 
                                                                      // Primer cero, el índice de los valores de la lista que se va a introducir, cuántos caracteres vamos a querer y el formato va a ser dígitos a 3. 

        // Actualizamos marcador
        txtlives.text = GameManager.Lives.ToString();
    }
}
