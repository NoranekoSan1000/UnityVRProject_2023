using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHands : MonoBehaviour
{

    [SerializeField] private GameObject CenterCamera;
    [SerializeField] private GameObject RightController;
    [SerializeField] private GameObject LeftControlelr;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("‚¸‚ê" + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       
        RightController.transform.parent = transform;
        LeftControlelr.transform.parent = transform;
    }
}
