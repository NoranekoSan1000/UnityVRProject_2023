using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRControllerInput : MonoBehaviour
{
    private bool leftHanded;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) Debug.Log("ROneTouch");
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch)) Debug.Log("RTwoTouch");
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) Debug.Log("RIndexTrigger");
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) Debug.Log("RHandTrigger");
        
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch)) Debug.Log("LOneTouch");
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch)) Debug.Log("LTwoTouch");
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) Debug.Log("LIndexTrigger");
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) Debug.Log("LHandTrigger");
        
    }
}
