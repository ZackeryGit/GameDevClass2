using UnityEngine;

[CreateAssetMenu(fileName = "NewFloatData", menuName = "Data Object/Float Data")]
public class FloatData : ScriptableObject
{
    public float value;

    public void UpdateValue(float num)
    {
        value += num;
    }

    public void SetValue(float num)
    {
        value = num;
    }
}
