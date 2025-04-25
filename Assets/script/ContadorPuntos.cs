using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorPuntos : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;

    void Update()
    {
        textoPuntaje.text = "Puntos: " + DestroyOnCollision.puntos;
    }
}
