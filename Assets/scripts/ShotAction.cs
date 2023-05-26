using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShotAction : MonoBehaviour
{
    [SerializeField] private HandStatus handStatus;

    [SerializeField] private GameObject Original_Bullet;

    [SerializeField] private GameObject HandGunModel_Right;
    [SerializeField] private GameObject HandGunModel_Left;
    [SerializeField] private GameObject GunLauncher_Right;
    [SerializeField] private GameObject GunLauncher_Left;

    [SerializeField] private AudioClip SE_shot;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (handStatus.RightHandStatus == "HandGun")
        {
            HandGunModel_Right.SetActive(true);
        }
        else HandGunModel_Right.SetActive(false);
        if (handStatus.LeftHandStatus == "HandGun")
        {
            HandGunModel_Left.SetActive(true);
        }
        else HandGunModel_Left.SetActive(false);

        if (handStatus.RightHandStatus == "HandGun" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            audioSource.PlayOneShot(SE_shot);
            SelectShot(GunLauncher_Right, 2000);
        }
        if (handStatus.LeftHandStatus == "HandGun" && OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            audioSource.PlayOneShot(SE_shot);
            SelectShot(GunLauncher_Left, 2000);
        }
    }

    public void SelectShot(GameObject launcher,int Speed)
    {
        Vector3 force = launcher.transform.forward * Speed;
        var pos = launcher.transform.position;
        var rot = launcher.transform.localRotation;
  
        GameObject Copy_Shot = Instantiate(Original_Bullet, pos,rot) as GameObject;
        Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        Destroy(Copy_Shot, 2.0f);
    }
}
