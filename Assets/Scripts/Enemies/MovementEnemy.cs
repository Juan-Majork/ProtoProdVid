using UnityEditor.Tilemaps;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 movement;

    private Rigidbody2D rb;
    private GameObject player;
    private Transform playerTransform;

    private bool isRight = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        movement = new Vector2(direction.x, 0);

        rb.MovePosition(rb.position + movement  * speed * Time.deltaTime);

        if (rb.linearVelocityX > 0 && !isRight)
        {
            Flip();
        }
        if (rb.linearVelocityX < 0 && isRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1f;
        transform.localScale = currentScale;

        isRight = !isRight;
    }
}
