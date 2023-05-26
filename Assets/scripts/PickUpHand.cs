using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHand : MonoBehaviour
{
    [SerializeField] private HandStatus handStatus;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "DropObject")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
            {
                if (handStatus.RightHandStatus != "") return;
                handStatus.setRightHand(other.name);
                Destroy(other);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
            {
                if (handStatus.LeftHandStatus != "") return;
                handStatus.setLeftHand(other.name);
                Destroy(other);
            }
        }
    }
}
