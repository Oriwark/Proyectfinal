using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarNivel2D : MonoBehaviour
{
    [SerializeField] private string nombreEscena; // Nombre de la escena a cargar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca la zona de reinicio
        {
            Debug.Log("Jugador tocó el trigger. Reiniciando nivel...");
            ReiniciarEscena();
        }
    }

    private void ReiniciarEscena()
    {
        string escena = string.IsNullOrEmpty(nombreEscena) ? SceneManager.GetActiveScene().name : nombreEscena;
        SceneManager.LoadScene(escena);
    }
}
