using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float vida;
    public event EventHandler OnTakeDamage;
    private Animator animator;
    public event EventHandler MuerteJugador;
    private Rigidbody2D rigidbody2;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida > 0)
        {
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Death");
            Physics2D.IgnoreLayerCollision(7, 8, true);
        }
    }
    public void Destruir()
    {
        Destroy(gameObject);
    }

    public void MuerteJugadorEvento()
    {
        MuerteJugador?.Invoke(this, EventArgs.Empty);
    }
}

