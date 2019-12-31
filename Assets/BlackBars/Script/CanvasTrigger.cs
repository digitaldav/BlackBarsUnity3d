using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTrigger : MonoBehaviour {

    public BlackBarController BarCanvas;
    

    void Start() {
        
    }


    private void OnTriggerEnter(Collider col) {

        if(BarCanvas != null) {

            BarCanvas.enabled = true;
            this.enabled = false;
        }


    }
}
