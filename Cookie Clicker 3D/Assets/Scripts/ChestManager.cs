using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestManager : MonoBehaviour
{
    
    public FloatGameAction chestOpenAction;
    public CookieManager cookieManager;
    public Stat chestMultiplier;

    public UnityEvent onOpen;


    public void Awake()
    {
        chestOpenAction.raise += chestReward;
    }

    private void chestReward(float multiplier){
        
        double loot = cookieManager.CalculateBaseClick() * multiplier;

        // Boost by the stat "Chest Multiplier"
        loot *= chestMultiplier.GetFinalValue();

        cookieManager.cookies.value += loot;

        onOpen.Invoke();

    }



}
