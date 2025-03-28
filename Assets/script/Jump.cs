using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int jumpsLeft;

    private Rigidbody2D rb;
    private Animator anim;  // ? Agregamos el Animator
    private bool isGrounded;
    private bool isDoubleJumping; // ? Nueva variable para controlar la animaci�n

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // ? Obtener el Animator
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        CheckGround();

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            Jump();
        }

        // Actualizar el par�metro de animaci�n
        anim.SetBool("capi rayo", isDoubleJumping);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsLeft--;

        // Activamos la animaci�n si es el segundo salto
        if (jumpsLeft == 0)
        {
            isDoubleJumping = true;
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpsLeft = maxJumps;
            isDoubleJumping = false; // Reseteamos la animaci�n al tocar el suelo
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
