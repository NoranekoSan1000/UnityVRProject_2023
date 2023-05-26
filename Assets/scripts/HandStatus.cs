using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandStatus : MonoBehaviour
{
    [SerializeField] private string _rightHandStatus;
    public string RightHandStatus => _rightHandStatus;

    [SerializeField] private string _leftHandStatus;
    public string LeftHandStatus => _leftHandStatus;

    public void setRightHand(string setObject)
    {
        _rightHandStatus = setObject;
    }
    public void setLeftHand(string setObject)
    {
        _leftHandStatus = setObject;
    }

    public HandStatus()
    {
        _rightHandStatus = "";
        _leftHandStatus = "";
    }
}
