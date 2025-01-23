using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour
{

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            HandleTap();
        }
    }

    private void HandleTap(){

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)){
            
            TappableObject tappableObject = hit.collider.GetComponent<TappableObject>();
            if (tappableObject != null){
                tappableObject.Tap();
            }
        }
    }

}