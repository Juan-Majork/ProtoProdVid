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

    private bool canJump;
    private bool isRight = true;

    private magicsScript magicsScript;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        magicsScript = Object.FindAnyObjectByType<magicsScript>();
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
        //Saltar
        if (collision.gameObject.CompareTag("floor"))
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //colision jugador con magic drops
        if (collision.gameObject.CompareTag("fire") && magicsScript.fullMagic < 2)
        {
            magicsScript.fireAtk = true;
            magicsScript.fullMagic++;
        }
        if (collision.gameObject.CompareTag("water") && magicsScript.fullMagic < 2)
        {
            magicsScript.waterAtk = true;
            magicsScript.fullMagic++;
        }
        if (collision.gameObject.CompareTag("rock") && magicsScript.fullMagic < 2)
        {
            magicsScript.rockAtk = true;
            magicsScript.fullMagic++;
        }
    }
}
