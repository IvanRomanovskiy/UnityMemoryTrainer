using UnityEngine;
using UnityEngine.UI;

public class ScoreRenderer : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Awake()
    {
        ScoreManager.OnScoreValueChangedEvent += OnScoreValueChanged;
        ScoreManager.ClearScore();
    }

    private void OnScoreValueChanged(int newLivesValue)
    {
        scoreText.text = $"Score: {newLivesValue}";
    }

    private void OnDestroy()
    {
        ScoreManager.OnScoreValueChangedEvent -= OnScoreValueChanged;
    }
}
