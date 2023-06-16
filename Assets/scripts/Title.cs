using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText_1;
    [SerializeField] private GameObject MoveInput;
    [SerializeField] private ReSetTrackingSpace resetTrackingSpace;

    private void Start()
    {
        MoveInput.SetActive(false);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            titleText_1.text = "";
            resetTrackingSpace.FirstStickInput = true;
            MoveInput.SetActive(true);
        }
    }
}
