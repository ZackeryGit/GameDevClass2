using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/Upgrade")]

public class Upgrade : ScriptableObject
{

    public string upgradeName;
    public int currentLevel;
    public int maxLevel;
    public double baseCost;
    public string description;
    public List<UpgradeReq> prerequisites;
    
    public double GetUpgradeCost(){
        return baseCost * (currentLevel + 1);
    }
    
    public bool CanUpgrade(){
        if (currentLevel >= maxLevel){
            return false;
        }
        return true;
    }

    public bool PrerequisitesMet(List<Upgrade> allUpgrades){
        
        if (prerequisites == null){
            Debug.Log("No preq");
            return true;
        }

        foreach (var prerequisite in prerequisites){
            if (!(allUpgrades.Contains(prerequisite.upgrade) && prerequisite.level <= prerequisite.upgrade.currentLevel)){
                Debug.Log("Didnt meet Preq");
                return false;
            }
        }

        Debug.Log("Preq Met");
        return true;
    }

    public void SetLevel(int level){
        currentLevel = level;
    }

}
