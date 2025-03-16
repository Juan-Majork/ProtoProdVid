using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private float timeToCharge;

    public void LoadSelected()
    {
        Invoke(nameof(SelectScene), timeToCharge);
    }
    private void SelectScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
