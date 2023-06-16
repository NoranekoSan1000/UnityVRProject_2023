using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private GameObject moveinput;
    [SerializeField] private GameObject playerstatus;
    [SerializeField] private ReSetTrackingSpace resetTrackingSpace;

    private bool pressA = false;

    private void Start()
    {
        moveinput.SetActive(false);
        playerstatus.SetActive(false);
    }

    private void Update()
    {
        if (!pressA && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            titleText.text = "";
            resetTrackingSpace.FirstStickInput = true;
            moveinput.SetActive(true);
            playerstatus.SetActive(true);
            pressA = true;
        }
    }
}
