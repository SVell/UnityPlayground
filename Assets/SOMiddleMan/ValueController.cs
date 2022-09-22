using SVell.ValueMiddleMan;
using UnityEngine;

public class ValueController : MonoBehaviour
{
    [SerializeField] private ValueMiddleMan valueMiddleMan;

    public void OnValueChanged()
    {
        Debug.Log($"Value changed: {valueMiddleMan.Value}");
    }
}
