using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHands : MonoBehaviour
{
    [SerializeField] private GameObject armature;
    [SerializeField] private GameObject TrackingSpace;
    [SerializeField] private GameObject CenterCam;


    const float MOVE = 0.01f;


    // Update is called once per frame
    void Update()
    {
        
        var area = TrackingSpace.transform.position;
        var arm = armature.transform.position;
        var center = CenterCam.transform.position;

        Debug.Log(center.x + " " + arm.x);
        Debug.Log(center.y + " " + arm.y);
        Debug.Log(center.z + " " + arm.z);

        area.z = -(center.z - arm.z);

        if (Input.GetKeyDown(KeyCode.Y)) TrackingSpace.transform.position = new Vector3(area.x, area.y, area.z);
    }
}
