using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineStatBehavior : MonoBehaviour
{
    public Stat intervalStat;
    public CoroutineBehavior coroutineBehavior;

    public void Awake(){
        coroutineBehavior.UpdateWaitTime((float)intervalStat.baseValue);
        Debug.Log("test");
    }

    public void OnEnable()
    {
        intervalStat.OnStatChanged += coroutineBehavior.UpdateWaitTime;
    }

    public void OnDisable()
    {
        intervalStat.OnStatChanged -= coroutineBehavior.UpdateWaitTime;
    }

}
