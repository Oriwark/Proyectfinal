using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocidad;
    
    [SerializeField] private Transform controladorSuelo;
    
    [SerializeField] private float distancia;

    [SerializeField] private bool moviendoIzquierda;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if(informacionSuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoIzquierda = !moviendoIzquierda;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
     if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().TomarDaño(5);
        }   
    }

}
