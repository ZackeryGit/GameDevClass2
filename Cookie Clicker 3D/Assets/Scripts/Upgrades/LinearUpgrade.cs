using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LinearUpgrade", menuName = "Upgrades/Modifier/LinearUpgrade")]
public class LinearUpgrade : ModifierUpgrade
{
    public double modifierBase;
    public double modifierLinear;

    public override double getScaledValue()
    {
        return (currentLevel * modifierLinear) + modifierBase;
    }
}
