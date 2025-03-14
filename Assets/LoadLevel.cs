using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private float timepoAntesDeIniciar;

    public void chargeLevel()
    {
        Invoke(nameof(selectLevel), timepoAntesDeIniciar);
    }

    private void selectLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
