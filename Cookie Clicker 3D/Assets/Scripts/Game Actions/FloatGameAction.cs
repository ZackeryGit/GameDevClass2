using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Float Action", menuName = "Actions/Float Action")]
public class FloatGameAction : ScriptableObject
{

public UnityAction<float> raise;

    public void RaiseAction(float value){
        raise?.Invoke(value);
    }


}
