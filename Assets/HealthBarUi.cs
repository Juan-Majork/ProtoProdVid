using UnityEngine;

public class HealthBarUi : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBarForgroundimage;

    public void UpadeteHealthBar (HealthController controller)
    {
        healthBarForgroundimage.fillAmount = controller.porcentajeVida;
    }
}
