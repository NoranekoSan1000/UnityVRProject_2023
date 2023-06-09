using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHands : MonoBehaviour
{
    [SerializeField] private GameObject armature;
    [SerializeField] private GameObject Center;

    private CharacterController characterController;

    const float MOVE = 0.01f;

    private void Start()
    {
        characterController = armature.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var center = Center.transform.position;
        var arm = armature.transform.position;
        var ctrl = characterController.center;

        Debug.Log(center.x + " " + arm.x);
        Debug.Log(center.y + " " + arm.y);
        Debug.Log(center.z + " " + arm.z);

        ctrl.Set(ctrl.x, ctrl.y, ctrl.z);
        
       
    }
}
