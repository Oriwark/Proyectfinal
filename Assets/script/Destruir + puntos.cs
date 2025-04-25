using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public static int puntos = 0; // Contador estático para sumar puntos

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            Destroy(gameObject); // Destruye el objeto actual
            puntos++;  // Suma 1 punto
            Debug.Log("Puntos: " + puntos);
        }
    }
}
