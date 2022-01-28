using UnityEngine;
using UnityEngine.UI;

public class LivesRenderer : MonoBehaviour
{
    [SerializeField] private Text text;

    void Awake()
    {
        LivesManager.OnLivesValueChangedEvent += OnLivesValueChangedEvent;
    }

    private void OnLivesValueChangedEvent(object sender, int newLivesValue)
    {
        text.text = $"Lives: {newLivesValue}";
    }

    private void OnDestroy()
    {
        LivesManager.OnLivesValueChangedEvent -= OnLivesValueChangedEvent;
    }
}
