using UnityEngine;

public class RechargeMagic : MonoBehaviour
{
    [SerializeField] 
    private float manaRestore;

    [SerializeField]
    private bool fireMagic;
    [SerializeField]
    private bool waterMagic;
    [SerializeField]
    private bool rockMagic;

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
