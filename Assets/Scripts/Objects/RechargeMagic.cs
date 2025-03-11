using UnityEngine;

public class RechargeMagic : MonoBehaviour
{
    [SerializeField] 
    private float manaRestore;

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            AttackSystem attackSystem = collision.gameObject.GetComponent<AttackSystem>();
            attackSystem.mana = manaRestore;
            Destroy (gameObject);
        }
    }
    */
}
