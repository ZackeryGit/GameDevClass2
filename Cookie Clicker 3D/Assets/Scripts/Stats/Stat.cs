using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "Stats/Stat")]
public class Stat : ScriptableObject
{

    public event Action<float> OnStatChanged;

    public double baseValue;
    private Dictionary<string, Modifier> modifiers = new Dictionary<string, Modifier>();

    public void AddorUpdateModifier(Modifier modifier){
        Debug.Log("Modifer Added to: " + name);
        modifiers[modifier.modifierName] = modifier;
        NotifyStatChange();
    }

    public void RemoveModifier(string modifierName){

        if (modifiers.ContainsKey(modifierName)){
            modifiers.Remove(modifierName);
            NotifyStatChange();
        }

    }

     public double GetFinalValue()
    {
        double finalValue = baseValue;
        double multiplicativeFactor = 1.0; // For multipliers and divisors

        foreach (var kvp in modifiers)
        {
            Modifier modifier = kvp.Value;

            switch (modifier.modifierType)
            {
                case ModifierType.Additive:
                    finalValue += modifier.value;
                    break;
                case ModifierType.Subtractive:
                    finalValue -= modifier.value;
                    break;
                case ModifierType.Multiplicative:
                    multiplicativeFactor *= modifier.value;
                    break;
                case ModifierType.Divisive:
                    if (modifier.value != 0) 
                        multiplicativeFactor /= modifier.value;
                    break;
            }
        }

        return finalValue * multiplicativeFactor;
    }

    private void NotifyStatChange()
    {
        OnStatChanged?.Invoke((float)GetFinalValue());
    }

}
