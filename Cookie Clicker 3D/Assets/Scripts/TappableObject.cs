using UnityEngine;
using UnityEngine.Events;

public class TappableObject : MonoBehaviour
{
    public UnityEvent onTap;

    public void Tap(){
        onTap.Invoke();
        print("Tapped!");
    }


    
}
