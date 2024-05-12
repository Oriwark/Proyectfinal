using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarNivel : MonoBehaviour
{
    [SerializeField] private GameObject[] parteNivel;

    [SerializeField] private float distanciaMinima;

    [SerializeField] private Transform puntoFinal;

    [SerializeField] private int cantidadInicial;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < cantidadInicial; i++)
        {
            GenerarParteNivel();
        }
    }

    private void Update()
    {
        if (Vector2.Distance(jugador.position, puntoFinal.position) < distanciaMinima)
        {
            GenerarParteNivel();
        }
    }

    private void GenerarParteNivel()
    {
        int numeroAleatorio = Random.Range(0, parteNivel.Length);
        GameObject nivel = Instantiate(parteNivel[numeroAleatorio], puntoFinal.position, Quaternion.identity);
        puntoFinal = BuscarPuntoFinal(nivel, "PuntoFinal");
    }

    private Transform BuscarPuntoFinal(GameObject parteNivel, string etiqueta)
    {
        Transform punto = null;
        foreach (Transform ubicacion in parteNivel.transform) { 
        
        if(ubicacion.CompareTag(etiqueta))
            {
                punto = ubicacion;
                break;
            }
        }
        return punto;
    }
}
