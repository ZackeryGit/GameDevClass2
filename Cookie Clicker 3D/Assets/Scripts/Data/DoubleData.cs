using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewDoubleData", menuName = "Data Object/Double Data")]
public class DoubleData : ScriptableObject
{
    public double value;
    

    public void UpdateValue(double num)
    {
        value += num;
    }
}
