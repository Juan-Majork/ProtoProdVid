using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HealthController>())
        {
            HealthController healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.recibirDaño(damage);
        }
    }
}
