
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLabelBehavior : MonoBehaviour
{
    private Text label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<Text>();
        Debug.Log("Start");
        startEvent.Invoke();
    }

    public void UpdateLabel (FloatData obj)
    {
        label.text = obj.value.ToString();
    }

    public void UpdateLabel(IntData obj){
        label.text = obj.value.ToString();
        Debug.Log(obj.value);
    }

    public void UpdateLabel (StringData obj){
        label.text = obj.value;
    }
}
