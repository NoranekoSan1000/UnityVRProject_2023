using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultPos : MonoBehaviour
{
    [SerializeField] private GameObject OVRCameraRig;

    private void Update()
    {
        transform.position = new Vector3(OVRCameraRig.transform.position.x, transform.position.y, OVRCameraRig.transform.position.z);
    }
}
