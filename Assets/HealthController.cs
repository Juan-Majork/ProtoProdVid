using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximaVida;

    public float porcentajeVida
    {
        get
        {
            return vida / maximaVida;
        }
    }

    public bool invencible { get; set; }

    public void recibirDaño(float daño)
    {
        if (vida == 0)
        {
            return;
        }

        if (invencible)
        {
            return;
        }

        vida -= daño;

        cambioEnVida.Invoke();

        if (vida < 0)
        {
            vida = 0;
        }

        if (vida == 0)
        {
            muerte.Invoke();
        }
        else
        {
            onDaño.Invoke();
        }
    }

    public void agregarVida(float curar)
    {
        if (vida == maximaVida)
        {
            return;
        }

        vida += curar;

        cambioEnVida.Invoke();

        if (vida > maximaVida)
        {
            vida = maximaVida;
        }
    }

    public UnityEvent muerte;
    public UnityEvent onDaño;
    public UnityEvent cambioEnVida;
}
