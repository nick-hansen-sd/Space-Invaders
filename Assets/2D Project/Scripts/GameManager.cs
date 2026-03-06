using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int totalScore;
    public TextMeshProUGUI scoreboard;
    void Start()
    {
       // todo - sign up for notification about enemy death
       Enemy.OnEnemyDied += OnEnemyDied;
       IndependentEnemy.OnIndependentEnemyDied += OnIndependentEnemyDied;
       totalScore = 0;
    }

    void OnDestroy()
    {
        Enemy.OnEnemyDied -= OnEnemyDied;
        IndependentEnemy.OnIndependentEnemyDied -= OnIndependentEnemyDied;
    }

    void OnEnemyDied(float score)
    {
        Debug.Log($"Killed enemy worth {score}");
        totalScore += (int)score;
        scoreboard.text = $"Score: {totalScore:d4}";
    }

    void OnIndependentEnemyDied(float score)
    {
        Debug.Log($"Killed bonus enemy worth {score}");
        totalScore += (int)score;
        scoreboard.text = $"Score: {totalScore:d4}";
    }
}
