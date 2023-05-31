using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFront : MonoBehaviour
{
    [SerializeField] private GameObject LookPos;

    public void Update()
    {
        var CharaDirection = LookPos.transform.position - transform.position;
        CharaDirection.y = 0;
        var lookRotation = Quaternion.LookRotation(CharaDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1.5f);

    }
}
