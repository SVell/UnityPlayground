using SVell.ValueMiddleMan;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button addValue;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ValueMiddleMan valueMiddleMan;

    private void Start()
    {
        addValue.onClick.AddListener(() => valueMiddleMan.Value++);
        SetText();
    }

    public void SetText()
    {
        text.text = valueMiddleMan.Value.ToString();
    }
}
