using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UnlockUpgrade", menuName = "Upgrades/Modifier/UnlockUpgrade")]
public class UnlockUpgrade : Upgrade
{

    public UnityEvent unlock;

    public override void applyUpgrade()
    {
        if (currentLevel >= 1){
            unlock.Invoke(); // Event that enables the unlock
        }
    }

    public override void removeUpgrade()
    {
        
    }
}
