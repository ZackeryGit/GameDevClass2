using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierUpgrade : Upgrade
{

    public ModifierType modifierType;
    public List<Stat> appliedStats;

    private Modifier appliedModifier;

    public override void applyUpgrade()
    {
        if (currentLevel <= 0){
            return;
        }
        appliedModifier = new Modifier(this.name, getScaledValue(), modifierType);
        foreach (Stat stat in appliedStats){
            stat.AddorUpdateModifier(appliedModifier);
        }
    }

    public override void removeUpgrade()
    {
        foreach (Stat stat in appliedStats){
            stat.RemoveModifier(appliedModifier.modifierName);
        }
    }

    public abstract double getScaledValue();
}
