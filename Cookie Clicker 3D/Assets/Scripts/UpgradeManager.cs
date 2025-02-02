using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public DoubleData currency;
    public List<Upgrade> allUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var upgrade in allUpgrades){
            upgrade.SetLevel(0);
        }
    }

    public bool IsUpgradeAvailable(Upgrade upgrade){
        return upgrade.CanUpgrade() && upgrade.PrerequisitesMet(allUpgrades);
    }

    public void TryToUpgrade(Upgrade upgrade){
        if (IsUpgradeAvailable(upgrade) && currency.value >= upgrade.GetUpgradeCost()){
            currency.value -= upgrade.GetUpgradeCost();
            upgrade.currentLevel ++;
        }
    }
}
