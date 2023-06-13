using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs starterAssetsInput;

    public int inputX;
    public int inputY;

    public int rotateInputX;
    public int rotateInputY;

    public Vector2 moveValue;
    public Vector2 lookValue;

    void Update()
    {
        Move();
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.RTouch)) rotateInputY = 1;
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch)) rotateInputY = -1;
        else inputY = 0;
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch)) rotateInputX = 1;
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch)) rotateInputX = -1;
        else inputX = 0;
        lookValue = new Vector2(rotateInputX, rotateInputY);
        starterAssetsInput.LookInput(lookValue);


        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger)) starterAssetsInput.SprintInput(true);
        else starterAssetsInput.SprintInput(false);

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) starterAssetsInput.JumpInput(true);

    }

    private void Move()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch)) inputY = 1;
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch)) inputY = -1;
        else inputY = 0;
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch)) inputX = 1;
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch)) inputX = -1;
        else inputX = 0;
        moveValue = new Vector2(inputX, inputY);
        starterAssetsInput.MoveInput(moveValue);
    }
}
