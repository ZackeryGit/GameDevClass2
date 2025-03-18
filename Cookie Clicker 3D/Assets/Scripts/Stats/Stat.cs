using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stats/Stat")]
public class Stat : ScriptableObject
{
    public double baseValue;
    private Dictionary<string, Func<double, double>> modifiers = new Dictionary<string, Func<double, double>>();

    public void AddorUpdateModifier(string key, Func<double, double> modifier){
        modifiers[key] = modifier;
    }

    public void RemoveModifier(string key){

        if (modifiers.ContainsKey(key)){
            modifiers.Remove(key);
        }

    }

    public double GetFinalValue()
    {
        double finalValue = baseValue;
        foreach (var modifier in modifiers.Values){
            finalValue = modifier(finalValue);
        }
        return finalValue;
    }

}
