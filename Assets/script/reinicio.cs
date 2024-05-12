using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class reinicio : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private HealthManager healthManager;
    
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Start()
    {
        healthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
        healthManager.MuerteJugador += AbrirMenu;
    }
    private void AbrirMenu(object sender, EventArgs e)
    {
        menu.SetActive(true);
    }
}
