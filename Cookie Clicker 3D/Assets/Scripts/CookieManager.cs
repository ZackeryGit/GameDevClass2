using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class CookieManager : MonoBehaviour
{

    public double baseClicks = 1;
    public DoubleData cookies;
    public StringData cookieText;
    public UnityEvent onCookiesUpdated;

    public double CalcClickedCookies(){

        double totalCookies = baseClicks;

        return totalCookies;
    }

    public double CalcPassiveCookies(){
        return 1;
    }

    

    public void CookieClicked(){
        double addedCookies = CalcClickedCookies();
        cookies.value = cookies.value + addedCookies;
        cookieText.value = FormatNumber(cookies.value) + " Cookies";
        onCookiesUpdated.Invoke();
    }

    public string FormatNumber(double num){

        if (num < 1e6) {
            return num.ToString("N0");
        } else {
            return NumberFormatter.AbbreviatedFormat(num);
        }
        
    }

}
