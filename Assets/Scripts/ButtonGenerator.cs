using UnityEngine;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour
{


    private float buttonSizeX;
    private float buttonSizeY;

    [SerializeField] private int size;
    [SerializeField] private float padding;
    [SerializeField] private GameObject panel;

    void Start()
    {
        buttonSizeX = (panel.GetComponent<RectTransform>().sizeDelta.x - (size + 1) * padding)/size;
        buttonSizeY = (panel.GetComponent<RectTransform>().sizeDelta.y - (size + 1) * padding) / size;

        var x = panel.transform.position.x - panel.GetComponent<RectTransform>().sizeDelta.x/2f + buttonSizeX/2f + padding;
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

    }
}
