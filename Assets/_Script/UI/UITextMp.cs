using UnityEngine;
using TMPro;

public class UITextMp : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float score = 0;

    private void OnEnable()
    {
        Enemy.EnemyDie += ScoreText;
    }

    private void OnDisable()
    {
        Enemy.EnemyDie -= ScoreText;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void ScoreText()
    {
        score += 20;
        UpdateScoreText();
    }

    protected virtual void UpdateScoreText()
    {
        scoreText.text = "Điểm: " + score;
    }
}