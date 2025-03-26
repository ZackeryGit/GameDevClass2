using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    public DoubleData currency;
    public List<Upgrade> allUpgrades;

    public Upgrade selectedUpgrade;
    public UnityEvent onAnyUpgrade, onStart;
    
    // Runs whenever an upgrade is "Selected", Getting the upgrade
    public static event Action<Upgrade> OnUpgradeButtonSelected;
    // Runs on any button selected, activates other things
    public UnityEvent onSelected;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var upgrade in allUpgrades){
            upgrade.SetLevel(0);
        }
        onStart.Invoke();
        foreach (var upgrade in allUpgrades){
            upgrade.applyUpgrade();
        }
    }

    public bool IsUpgradeAvailable(Upgrade upgrade){
        return upgrade.CanUpgrade() && upgrade.PrerequisitesMet(allUpgrades);
    }

    // If you can buy, buy
    public void TryToUpgrade(Upgrade upgrade){
        if (IsUpgradeAvailable(upgrade) && currency.value >= upgrade.GetUpgradeCost()){
            currency.value -= upgrade.GetUpgradeCost();
            upgrade.currentLevel ++;
            upgrade.applyUpgrade();
            onAnyUpgrade.Invoke();
        }
    }

    // Try to upgrade, but you have to have it in the selected field first to buy
    public void TryToUpgradeSelected (Upgrade upgrade){
            if (selectedUpgrade == upgrade) {
                TryToUpgrade(upgrade);
            } else {
                selectedUpgrade = upgrade;
                onSelected.Invoke();
                OnUpgradeButtonSelected(upgrade);
            }
    }

    public void UnselectUpgrade(){
        selectedUpgrade = null;
    }
}
