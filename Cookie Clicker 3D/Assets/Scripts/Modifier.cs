using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public enum ModifierType
{
    Additive,
    Subtractive,
    Multiplicative,
    Divisive
}

public class Modifier
{
    public string modifierName;
    public double value;
    public ModifierType modifierType;

    public Modifier(string modifierName, double value, ModifierType modifierType){

        this.modifierName = modifierName;
        this.value = value;
        this.modifierType = modifierType;    
        
    }
}
