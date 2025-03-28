using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Reemplaza "Enemy" con el tag que quieras detectar
        {
            Destroy(other.gameObject); // Destruye el objeto con el que colisiona
        }
    }
}
