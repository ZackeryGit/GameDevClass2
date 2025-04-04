using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SaveCurrencies : MonoBehaviour
{

    public List<DoubleData> currencies;

    public void SaveData(){
        foreach(DoubleData currency in currencies){

            PlayerPrefs.SetString(currency.name, currency.value.ToString());

        }

        PlayerPrefs.Save();

    }

    public void LoadData(){
        foreach(DoubleData currency in currencies){

            string doubleData = PlayerPrefs.GetString(currency.name, "0");
            currency.value = double.Parse(doubleData);

        }

        
    }
}
