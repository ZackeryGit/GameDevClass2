using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehavior : MonoBehaviour
{
    public UnityEvent startCountEvent, repeatCountEvent, endCountEvent, repeatUntilFalse;
    public IntData counterNum;
    private bool canRun;
    public float interval = 3.0f;
    private WaitForSeconds wfsObj;
    private WaitForFixedUpdate wffuObj;

    private Coroutine countingCoroutine;
    private Coroutine repeatUntilFalseCoroutine;

    public bool CanRun { get => canRun; set => canRun = value; }

    // Start is called before the first frame update

    private void Awake()
    {
        UpdateWaitTime(interval);
        wffuObj = new WaitForFixedUpdate();
    }

    public void startCounting()
    {
        if (countingCoroutine != null)          // Stop if already running
            StopCoroutine(countingCoroutine);

        countingCoroutine = StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        
        startCountEvent.Invoke();
        yield return wfsObj;
        while (counterNum.value > 0)
        {
            repeatCountEvent.Invoke();
            Debug.Log(counterNum.value);
            counterNum.value --;
            yield return wfsObj;
        }

        countingCoroutine = null;   
        endCountEvent.Invoke();

    }

    public void StartRepeatUntilFalse()
    {
        CanRun = true;

        if (repeatUntilFalseCoroutine != null)
            StopCoroutine(repeatUntilFalseCoroutine);

        repeatUntilFalseCoroutine = StartCoroutine(RepeatUntilFalse());
        Debug.Log("startrepeat");
    }



    private IEnumerator RepeatUntilFalse(){
        
        yield return wfsObj;
        Debug.Log("repeat1");
        while(CanRun)
        {
            repeatUntilFalse.Invoke();
            yield return wfsObj;
            Debug.Log("repeat");
        }

        repeatUntilFalseCoroutine = null;
    }

    public void UpdateWaitTime(float newInterval)
    {
        interval = newInterval;
        wfsObj = new WaitForSeconds(interval);

        // Restart both coroutines if they're active
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
            countingCoroutine = StartCoroutine(Counting());
        }

        if (repeatUntilFalseCoroutine != null)
        {
            StopCoroutine(repeatUntilFalseCoroutine);
            repeatUntilFalseCoroutine = StartCoroutine(RepeatUntilFalse());
        }
    }
}
