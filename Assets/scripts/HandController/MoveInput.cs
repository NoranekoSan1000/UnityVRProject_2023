using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    public int inputX;
    public int inputY;

    public Vector2 moveValue;

    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch)) inputY = 1;
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch)) inputY = -1;
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch)) inputX = 1;
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch)) inputX = -1;
        moveValue = new Vector2(inputX,inputY);
    }
}
