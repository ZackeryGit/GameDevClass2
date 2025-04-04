using UnityEngine;
using UnityEngine.Events;

public class SaveUpgrades : MonoBehaviour
{
    public UpgradeManager upgradeManager;
    public UnityEvent onSave, onLoad;

    public void SaveData(){
        foreach(Upgrade upgrade in upgradeManager.allUpgrades){

            PlayerPrefs.SetInt(upgrade.upgradeName, upgrade.currentLevel);

        }

        PlayerPrefs.Save();
        onSave.Invoke();

    }

    public void LoadData(){
        foreach(Upgrade upgrade in upgradeManager.allUpgrades){

            upgrade.currentLevel = PlayerPrefs.GetInt(upgrade.upgradeName, 0);
            
        }

        onLoad.Invoke();
        
    }
}
