using UnityEngine;
using TMPro;

public class ScoreUi : MonoBehaviour
{
    private TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();   
    }

    public void UpdateScore(ScoreController score)
    {
        scoreText.text = $"Score: {score.Score}";
    }
}
