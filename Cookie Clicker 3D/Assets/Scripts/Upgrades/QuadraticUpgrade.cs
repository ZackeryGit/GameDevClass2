using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuadraticUpgrade", menuName = "Upgrades/Modifier/QuadraticUpgrade")]
public class QuadraticUpgrade : ModifierUpgrade
{

    public double modifierBase;
    public double modifierLinear;
    public double modifierExpodential;
    public double modifierPower;

    public override double getScaledValue()
    {
        return modifierBase * Math.Pow(currentLevel, modifierPower) + (currentLevel * modifierLinear) + modifierBase;
    }
}
