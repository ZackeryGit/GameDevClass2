using System;
using UnityEngine;
using UnityEngine.Events;

public class CookieManager : MonoBehaviour
{
    public IntData totalClicks;
    public DoubleData cookies;
    public StringData cookieText;
    public UnityEvent onCookiesUpdated, onStart, turnGold, goldClick;
    public UpgradeManager upgradeManager;
    public Stat BaseClickStat;
    public Stat ClickMultiplier;   
    public Upgrade GoldenClicksUnlcok;
    public Stat clicksPerGold;

    private Boolean isGolden = false;

    public void Awake(){
        
    }

    public void Start()
    {
        onStart.Invoke();
    }

    public double CalculateBaseClick(){
        double totalCookies = BaseClickStat.GetFinalValue() * ClickMultiplier.GetFinalValue();

        totalCookies = Math.Floor(totalCookies);
        return totalCookies;
    }

    public double CalculatedBoostedClick(){
        double totalCookies = CalculateBaseClick();


        //Gold boost
        if (isGolden) {
            isGolden = false;
            goldClick.Invoke();
            totalCookies *= 2;
        }

        totalCookies = Math.Floor(totalCookies);
        return totalCookies;
    }

    public double CalcPassiveCookies(){
        return 1;
    }

    public void CookieClicked(){
        totalClicks.value ++;
        double addedCookies = CalculateBaseClick();
        cookies.value = cookies.value + addedCookies;
        onCookiesUpdated.Invoke();

        if ((totalClicks.value % clicksPerGold.GetFinalValue()) == 0 && GoldenClicksUnlcok.currentLevel == 1){
            TurnGolden();
        }

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

    // Status Effect
    public void TurnGolden(){
        Debug.Log("Golden");
        isGolden = true;
        turnGold.Invoke();
    }
    

}
