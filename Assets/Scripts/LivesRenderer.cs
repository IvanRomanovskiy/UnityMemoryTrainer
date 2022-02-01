using UnityEngine;
using UnityEngine.UI;

public class LivesRenderer : MonoBehaviour
{
    [SerializeField] private Text text;

    void Awake()
    {
        LivesManager.OnLivesValueChangedEvent += OnLivesValueChanged;
    }

    private void OnLivesValueChanged(int newLivesValue)
    {
        text.text = $"Lives: {newLivesValue}";
    }

    private void OnDestroy()
    {
        LivesManager.OnLivesValueChangedEvent -= OnLivesValueChanged;
    }
}
