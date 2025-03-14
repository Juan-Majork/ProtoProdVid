using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;

    public float hpPercentage
    {
        get
        {
            return hp / maxHp;
        }
    }

    public bool invencible { get; set; }

    public void receiveDamage(float damage)
    {
        if (hp == 0)
        {
            return;
        }

        if (invencible)
        {
            return;
        }

        hp -= damage;

        changeLife.Invoke();

        if (hp < 0)
        {
            hp = 0;
        }

        if (hp == 0)
        {
            death.Invoke();
        }
        else
        {
            onDamage.Invoke();
        }
    }

    public void restoreHP(float cure)
    {
        if (hp == maxHp)
        {
            return;
        }

        hp += cure;

        changeLife.Invoke();

        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }

    public UnityEvent death;
    public UnityEvent onDamage;
    public UnityEvent changeLife;

}
