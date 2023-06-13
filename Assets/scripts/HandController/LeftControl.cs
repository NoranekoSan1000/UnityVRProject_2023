using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftControl : MonoBehaviour
{
    [SerializeField] private HandStatus handStatus;

    private GameObject KeepLeftObject;

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
        
        if (other.gameObject.tag == "HandGun")
        {
            SearchObject("HandGun");
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
            {
                if (handStatus.LeftHandStatus != "") return;
                mostCloseObject.gameObject.SetActive(false);
                KeepLeftObject = mostCloseObject;         
                handStatus.setLeftHand(other.tag);              
            }
        }
        if (other.gameObject.tag == "AssaultRifle")
        {
            SearchObject("AssaultRifle");
            if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
            {
                if (handStatus.LeftHandStatus != "") return;
                mostCloseObject.gameObject.SetActive(false);
                KeepLeftObject = mostCloseObject;
                handStatus.setLeftHand(other.tag);
            }
        }
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch)) DropObject();
    }

    private void DropObject()
    {
        if (ReferenceEquals(KeepLeftObject, null)) return;
        KeepLeftObject.transform.position = this.transform.position;
        KeepLeftObject.SetActive(true);
        KeepLeftObject = null;
        handStatus.setLeftHand("");
    }

        public void SearchObject(string gun)
    {
        targets = GameObject.FindGameObjectsWithTag(gun);
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

