using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            HealthPlayer healthPlayer = collision.gameObject.GetComponent<HealthPlayer>();
            healthPlayer.receiveDamage(damage);
        }
    }
}
