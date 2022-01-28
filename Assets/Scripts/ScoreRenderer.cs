using UnityEngine;
using UnityEngine.UI;

public class ScoreRenderer : MonoBehaviour
{
    [SerializeField] private Text text;

    void Awake()
    {
        ScoreManager.OnScoreValueChangedEvent += OnScoreValueChanged;
    }

    private void OnScoreValueChanged(int newLivesValue)
    {
        text.text = $"Score: {newLivesValue}";
    }

    private void OnDestroy()
    {
        ScoreManager.OnScoreValueChangedEvent -= OnScoreValueChanged;
    }
}
