using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importante para manejar escenas

public class ReiniciarAlTocar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name); // Para depuración

        if (other.CompareTag("Player")) // Verifica que sea el jugador
        {
            Debug.Log("Reiniciando escena...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
