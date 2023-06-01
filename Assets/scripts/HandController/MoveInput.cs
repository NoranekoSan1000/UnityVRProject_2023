using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs starterAssetsInput;
    [SerializeField] private GameObject CenterEyeAnchor;

    public int inputX;
    public int inputY;

    public Vector2 moveValue;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch)) inputY = 1;
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch)) inputY = -1;
        else inputY = 0;
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch)) inputX = 1;
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch)) inputX = -1;
        else inputX = 0;
        moveValue = new Vector2(inputX,inputY);
        starterAssetsInput.MoveInput(moveValue);

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch)) starterAssetsInput.SprintInput(true);

    }
}
