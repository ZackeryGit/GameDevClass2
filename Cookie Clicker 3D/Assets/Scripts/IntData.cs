using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewIntData", menuName = "Data Object/Int Data")]
public class IntData : ScriptableObject
{

    public int value;

    public void UpdateValue(int num)
    {
        value += num;
    }

    public void SetValue(int num)
    {
        value = num;
    }
    public void SetValue(IntData num)
    {
        value = num.value;
    }

    public void CompareValue(IntData num){
        if (value < num.value) {
            value = num.value;
        }
    }
    
}
