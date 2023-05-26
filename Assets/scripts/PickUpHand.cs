using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHand : MonoBehaviour
{
    [SerializeField] private HandStatus handStatus;

    private GameObject KeepRightObject;
    private GameObject KeepLeftObject;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "DropObject")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
            {
                if (handStatus.RightHandStatus != "") return;
                other.gameObject.gameObject.SetActive(false);
                KeepRightObject = other.gameObject;
                handStatus.setRightHand(other.name);
            }
            else if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
            {
                if (handStatus.LeftHandStatus != "") return;
                other.gameObject.gameObject.SetActive(false);
                KeepLeftObject = other.gameObject;         
                handStatus.setLeftHand(other.name);              
            }
        }
    }

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (ReferenceEquals(KeepRightObject, null)) return;
            KeepRightObject.transform.position = this.transform.position;
            KeepRightObject.SetActive(true);
            KeepRightObject = null;
            handStatus.setRightHand("");
        }

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            if (ReferenceEquals(KeepLeftObject, null)) return;
            KeepLeftObject.transform.position = this.transform.position;
            KeepLeftObject.SetActive(true);
            KeepLeftObject = null;
            handStatus.setLeftHand("");
        }
    }
}
