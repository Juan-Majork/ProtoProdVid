using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedX;
    [SerializeField] 
    private float speedY;

    private float horizontalInput;
    private float verticalInput;

    private bool canJump;
    private bool isRight = true;

    private AttackSystem attackSystem;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        attackSystem = Object.FindAnyObjectByType<AttackSystem>();
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            rb.linearVelocityX = horizontalInput * speedX;
        }

        if (horizontalInput > 0 && !isRight)
        {
            Flip();
        }

        if (horizontalInput < 0 && isRight) 
        {
            Flip();
        }

        if (Input.GetKey("w") && canJump)
        {
            rb.AddForce (Vector2.up * speedY, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1f;
        transform.localScale = currentScale;

        isRight = !isRight;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fire"))
        {
            attackSystem.magicalBonus = 1;
        }
        if (collision.gameObject.CompareTag("water"))
        {
            attackSystem.magicalBonus = 2;
        }
        if (collision.gameObject.CompareTag("rock"))
        {
            attackSystem.magicalBonus = 3;

        }
    }
}
