using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlatGameActionHandler : MonoBehaviour
{
    public GameAction gameActionObj;
    public UnityEvent onRaiseEvent;
    // Start is called before the first frame update
    private void Awake()
    {
        gameActionObj.raise += OnAction;
    }

    private void OnAction()
    {
        onRaiseEvent.Invoke();
    }
    
}
