using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class CookieManager : MonoBehaviour
{

    public double baseClicks = 1;
    public DoubleData cookies;
    public StringData cookieText;
    public UnityEvent onCookiesUpdated;
    public UpgradeManager upgradeManager;
    private Upgrade clickMulti;

    public void Awake(){
        clickMulti = upgradeManager.allUpgrades.Find(u => u.upgradeName == "Click Multiplier");
    }

    public double CalcClickedCookies(){

        double totalCookies = baseClicks * (clickMulti.currentLevel + 1);

        return totalCookies;
    }

    public double CalcPassiveCookies(){
        return 1;
    }

    public void CookieClicked(){
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

}
