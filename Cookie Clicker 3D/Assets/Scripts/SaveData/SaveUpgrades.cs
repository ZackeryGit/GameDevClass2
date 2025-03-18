using UnityEngine;

public class SaveUpgrades : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    
    public void SaveData(){
        foreach(Upgrade upgrade in upgradeManager.allUpgrades){

            PlayerPrefs.SetInt(upgrade.upgradeName, upgrade.currentLevel);

        }

        PlayerPrefs.Save();

    }

    public void LoadData(){
        foreach(Upgrade upgrade in upgradeManager.allUpgrades){

            upgrade.currentLevel = PlayerPrefs.GetInt(upgrade.upgradeName, 0);

        }

        
    }
}
