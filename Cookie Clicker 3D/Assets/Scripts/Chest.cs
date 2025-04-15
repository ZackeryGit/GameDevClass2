using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int lootValue = 10; // or make this randomized, etc.
    public FloatGameAction floatAction;

    public void OpenChest() // or use a button/UI event/etc.
    {
        floatAction.RaiseAction(10);
    }
}
