using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField]
    public float mana;

    [SerializeField]
    private Transform baseSpawn;
    [SerializeField]
    private Transform upSpawn;
    [SerializeField]
    private Transform downSpawn;

    [SerializeField]
    private GameObject baseAttack;
    [SerializeField]
    private GameObject upAttack;
    [SerializeField]
    private GameObject downAttack;

    private void Awake()
    {
        mana = 0f;
    }
}
