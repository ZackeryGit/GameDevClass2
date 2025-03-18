using UnityEngine;

[CreateAssetMenu(fileName = "NewStringData", menuName = "Data Object/String Data")]
public class StringData : ScriptableObject
{
    public string value;

    public void SetValue(string text)
    {
        value = text;
    }
}
