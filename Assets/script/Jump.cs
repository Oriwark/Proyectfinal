using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public int maxJumps = 2;
    private int jumpsLeft;

    private Rigidbody2D rb;
    private Animator anim;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        CheckGround();

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            Jump();

            if (jumpsLeft == 0)
            {
                anim.SetTrigger("DoubleJump"); // Lanzar solo en el segundo salto
            }
        }


    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0); // Reinicia velocidad Y antes de saltar
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (jumpsLeft == 2)
        {
            anim.SetTrigger("Jump");
        }
        else if (jumpsLeft == 1)
        {
            anim.SetTrigger("DoubleJump");
        }

        jumpsLeft--;
    }


    void CheckGround()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            jumpsLeft = maxJumps;
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
