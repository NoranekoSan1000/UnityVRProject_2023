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
                handStatus.setRightHand(other.name);
                KeepRightObject = other.gameObject;
                KeepRightObject.gameObject.SetActive(false);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
            {
                if (handStatus.LeftHandStatus != "") return;
                handStatus.setLeftHand(other.name);
                KeepLeftObject = other.gameObject;
                KeepLeftObject.gameObject.SetActive(false);
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
