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
    [SerializeField] private GameObject AssaultRifleModel_Right;
    [SerializeField] private GameObject AssaultRifleModel_Left;
    [SerializeField] private GameObject GunLauncher_Right;
    [SerializeField] private GameObject GunLauncher_Left;

    [SerializeField] private AudioClip SE_shot;
    AudioSource audioSource;

    private float ShotCoolTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShotCoolTime >= 0) ShotCoolTime -= Time.deltaTime;
        _viewModel();
        _inputTrigger();
    }

    private void _viewModel()
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

        if (handStatus.RightHandStatus == "AssaultRifle")
        {
            AssaultRifleModel_Right.SetActive(true);
        }
        else AssaultRifleModel_Right.SetActive(false);

        if (handStatus.LeftHandStatus == "AssaultRifle")
        {
            AssaultRifleModel_Left.SetActive(true);
        }
        else AssaultRifleModel_Left.SetActive(false);
    }

    private void _inputTrigger()
    {
        if (handStatus.RightHandStatus == "HandGun" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            audioSource.PlayOneShot(SE_shot);
            SelectShot(GunLauncher_Right, 1000, "HandGun");
        }
        if (handStatus.LeftHandStatus == "HandGun" && OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            audioSource.PlayOneShot(SE_shot);
            SelectShot(GunLauncher_Left, 1000, "HandGun");
        }

        if (handStatus.RightHandStatus == "AssaultRifle" && OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            if (ShotCoolTime > 0.1f) return;
            audioSource.PlayOneShot(SE_shot);
            SelectShot(GunLauncher_Right, 1200, "AssaultRifle");
            ShotCoolTime = 0.25f;
        }
        if (handStatus.LeftHandStatus == "AssaultRifle" && OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            if (ShotCoolTime > 0.1f) return;
            audioSource.PlayOneShot(SE_shot);
            SelectShot(GunLauncher_Left, 1200, "AssaultRifle");
            ShotCoolTime = 0.25f;
        }
    }


    private void SelectShot(GameObject launcher,int Speed,string name)
    {
        Vector3 force = launcher.transform.forward * Speed;
        var pos = launcher.transform.position;
        var rot = launcher.transform.localRotation;
  
        GameObject Copy_Shot = Instantiate(Original_Bullet, pos,rot) as GameObject;
        Copy_Shot.tag = "PlayerShot";
        Copy_Shot.name = name + "Bullet";
        Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        Destroy(Copy_Shot, 2.0f);
    }
}
