using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Game Action", menuName = "Actions/Action")]
public class GameAction : ScriptableObject
{

public UnityAction raise;

    public void RaiseAction(){
        raise?.Invoke();
    }


}
