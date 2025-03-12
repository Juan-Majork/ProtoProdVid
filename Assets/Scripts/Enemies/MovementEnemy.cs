using UnityEditor.Tilemaps;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 movement;

    private Rigidbody2D rb;
    private GameObject player;
    private Transform playerTransform;

    public bool KBAct = false;

    private bool isRight = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {

            
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1f;
        transform.localScale = currentScale;

        isRight = !isRight;
    }
}
