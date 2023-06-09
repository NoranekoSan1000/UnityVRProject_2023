using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHand : MonoBehaviour
{
    [SerializeField] private HandStatus handStatus;

    private GameObject KeepRightObject;

    private GameObject[] targets;
    private GameObject mostCloseObject;
    private float closeDist;

    void Start()
    {
        mostCloseObject = null;
        closeDist = 2;
    }

    private void OnTriggerStay(Collider other)
    {
        SearchObject();
        if (other.gameObject.tag == "HandGun")
        {
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
            {
                if (handStatus.RightHandStatus != "") return;
                mostCloseObject.SetActive(false);
                KeepRightObject = mostCloseObject;
                handStatus.setRightHand(other.tag);
            }
        }
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) DropObject();
    }

    private void DropObject()
    {
        if (ReferenceEquals(KeepRightObject, null)) return;
        KeepRightObject.transform.position = this.transform.position;
        KeepRightObject.SetActive(true);
        KeepRightObject = null;
        handStatus.setRightHand("");    
    }

    public void SearchObject()
    {
        targets = GameObject.FindGameObjectsWithTag("HandGun");
        if(targets.Length == 0)
        {
            mostCloseObject = null;
            return;
        }
        foreach (GameObject t in targets)
        {
            float tDist = Vector3.Distance(this.transform.position, t.transform.position);

            if (closeDist > tDist)
            {
                closeDist = tDist;
                mostCloseObject = t;
            }
        }
        closeDist = 2;
    }

}
