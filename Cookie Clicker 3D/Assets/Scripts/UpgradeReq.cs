using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeRequirement", menuName = "Upgrades/UpgradeReq")]
public class UpgradeReq : ScriptableObject{
    public Upgrade upgrade;
    public int level;
}
