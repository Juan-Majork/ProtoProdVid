using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent OnScoreChange;

    public int Score {  get; set; }

    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChange.Invoke();
    }
}
