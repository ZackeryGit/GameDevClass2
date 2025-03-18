using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/Upgrade")]

public class Upgrade : ScriptableObject
{

    // Upgrade Info
    public string upgradeName;
    public Sprite image;
    public string description;

    public UnityEvent test;

    // Upgrade Level
    public int currentLevel;
    public int maxLevel;

    // Prerequisties
    public UpgradeReq mainPrerequisite;
    public List<UpgradeReq> prerequisites;

    // Cost List
    public List<double> costList;
    public bool useCostList = false;

    // Cost Equation
    public double baseCost;
    public double linearIncrease;
    public double quadraticalIncrease;
    public double scaleIntensity;
    

    public double GetUpgradeCost(){
        if (useCostList == true){
            return costList[currentLevel];
        } else {
            return Math.Floor(baseCost + (linearIncrease * currentLevel) + (quadraticalIncrease * Math.Pow(currentLevel, scaleIntensity)));
        }
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

    public bool MainPrerequisiteMet(List<Upgrade> allUpgrades){
        if (mainPrerequisite == null || allUpgrades.Contains(mainPrerequisite.upgrade) && mainPrerequisite.level <= mainPrerequisite.upgrade.currentLevel){
            return true;
        } else {
            return false;
        }
    }
    

    public void SetLevel(int level){
        currentLevel = level;
    }

}
