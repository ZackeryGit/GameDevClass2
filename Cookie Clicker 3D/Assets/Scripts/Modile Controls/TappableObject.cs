using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TappableObject : MonoBehaviour
{
    public UnityEvent onTap, onTapDelayed;
    public float delayTime = .5f;
    private WaitForSeconds wfs;

    private void Awake(){
        wfs = new WaitForSeconds(delayTime);
    }

    public void Tap(){
        StartCoroutine(HandleTap());
    }
    public IEnumerator HandleTap(){
        onTap.Invoke();
        print("Tapped!");
        yield return wfs;
        onTapDelayed.Invoke();
    }


    
}
