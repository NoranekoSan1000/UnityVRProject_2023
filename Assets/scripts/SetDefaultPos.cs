using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultPos : MonoBehaviour
{
    [SerializeField] private GameObject OVRCameraRig;

    private void Update()
    {
        OVRCameraRig.transform.position = transform.position;
    }
}
