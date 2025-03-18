using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class CookieManager : MonoBehaviour
{
    public IntData totalClicks;
    public DoubleData cookies;
    public StringData cookieText;
    public UnityEvent onCookiesUpdated, onStart;
    public UpgradeManager upgradeManager;
    private Upgrade clickMulti;
    private Upgrade baseClicks;

    private Boolean isGolden = false;

    public void Awake(){
        baseClicks = upgradeManager.allUpgrades.Find(u => u.upgradeName == "Base Clicks");
        clickMulti = upgradeManager.allUpgrades.Find(u => u.upgradeName == "Click Multiplier");
    }

    public void Start()
    {
        onStart.Invoke();
    }

    public double CalcClickedCookies(){

        double totalCookies = (baseClicks.currentLevel + 1) * (clickMulti.currentLevel + 1);
        totalCookies = Math.Floor(totalCookies);
        return totalCookies;
    }

    public double CalcPassiveCookies(){
        return 1;
    }

    public void CookieClicked(){
        totalClicks.value ++;
        double addedCookies = CalcClickedCookies();
        cookies.value = cookies.value + addedCookies;
        onCookiesUpdated.Invoke();
    }

    public void updateCookieText(){
        cookieText.value = FormatNumber(cookies.value) + " Cookies";
    }

    public string FormatNumber(double num){

        if (num < 1e6) {
            return num.ToString("N0");
        } else {
            return NumberFormatter.AbbreviatedFormat(num);
        }
        
    }

    private double CalculateBaseClicks(){

        
// Left off here
        return 1f;
    }

}
