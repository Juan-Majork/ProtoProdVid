using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBarForegroundImage;

    public void UptadeHealthBar (HealthPlayer healthPlayer)
    {
        healthBarForegroundImage.fillAmount = healthPlayer.hpPercentage;
    }
}
