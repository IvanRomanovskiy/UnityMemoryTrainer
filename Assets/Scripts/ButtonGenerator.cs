using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{
    public int size;

    private float buttonSizeX;
    private float buttonSizeY;

    
    [SerializeField] private float padding;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameController controller;
    [SerializeField] private SequenceGenerator sequence;

    private List<GameObject> buttonList;

    
    [SerializeField] private float delay;
    [SerializeField] private float timeDisplay;

    public delegate void ButtonOutpuHandler(int i, int j);
    public static event ButtonOutpuHandler onButtonPressedEvent;

    private void Awake()
    {
        SetButtonMatrix();
    }

    void Start()
    {
        StartCoroutine(DisplayAllCoroutine(sequence.sequence));
    }
    private void SetButtonMatrix()
    {
        buttonList = new List<GameObject>();

        buttonSizeX = (panel.GetComponent<RectTransform>().sizeDelta.x - (size + 1) * padding) / size;
        buttonSizeY = (panel.GetComponent<RectTransform>().sizeDelta.y - (size + 1) * padding) / size;

        var x = panel.transform.position.x - panel.GetComponent<RectTransform>().sizeDelta.x / 2f + buttonSizeX / 2f + padding;
        var y = panel.transform.position.y + panel.GetComponent<RectTransform>().sizeDelta.y / 2f - buttonSizeY / 2f - padding;


        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                CreateButton(i, j, x + (padding + buttonSizeX) * j, y);
            }
            y -= padding + buttonSizeY;
        }

    }

    void CreateButton(int i, int j, float x, float y)
    {
        var newButton = new GameObject($"{i} {j}",typeof(Image), typeof(Button));
        newButton.transform.SetParent(panel.transform);
        newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(buttonSizeX, buttonSizeY);
        newButton.transform.localScale = new Vector3(1, 1);
        newButton.transform.localPosition = new Vector3(x, y);
        newButton.GetComponent<Button>().onClick.AddListener(() => { onButtonPressedEvent?.Invoke(i, j); });
        buttonList.Add(newButton);
    }

    public void DisableAllButtons(bool action)
    {
        foreach (var item in buttonList)
        {
            item.GetComponent<Button>().interactable = !action;
        }
    }

    public IEnumerator changeColor(int i, int j, Color color)
    {
        ColorBlock colorVar = buttonList[i * size + j].GetComponent<Button>().colors;
        colorVar.disabledColor = color;
        buttonList[i * size + j].GetComponent<Button>().colors = colorVar;
        yield return new WaitForSecondsRealtime(timeDisplay);
        buttonList[i * size + j].GetComponent<Button>().colors = ColorBlock.defaultColorBlock;
    }
    public IEnumerator DisplayAllCoroutine(List<(int, int)> sequence)
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitUntil(() => controller.isBehavior(typeof(GameBehaviorMemorize)));
            yield return new WaitForSeconds(2);
            foreach (var item in sequence)
            {
                yield return changeColor(item.Item1, item.Item2, Color.blue);
                yield return new WaitForSeconds(delay);
            }
            controller.SetBehaviorRepeat();
        }
    }
    
}
