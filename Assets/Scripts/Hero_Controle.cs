using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Controle : MonoBehaviour
{
    public float speed;
    public float health;
    private bool facingRight;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            anim.SetBool("isRuning", false);
        }
        else
        {
            anim.SetBool("isRuning", true);
        }
        if (!facingRight && moveInput.x < 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x > 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
