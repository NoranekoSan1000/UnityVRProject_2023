using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyShot : MonoBehaviour
{
    public enum GunType
    {
        HandGun,
        ShotGun,
        AssaultRifle
    };
    [SerializeField] GunType gunType = GunType.HandGun;

    [SerializeField] private GameObject PlayerCenter;
    [SerializeField] private GameObject Original_Bullet;
    [SerializeField] private AudioClip Enshot;
    AudioSource audioSource;

    private float time;
    private int assaultCount = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        LookEnemy();
        time += Time.deltaTime;
        if (gunType == GunType.HandGun)
        {
            if (time > 2.0f) shot();
        }
        if (gunType == GunType.ShotGun)
        {
            if (time > 2.5f) shot();
        }
        if (gunType == GunType.AssaultRifle)
        {
            if (time > 0.1f)
            {
                shot();
                assaultCount++;
            }
        }
    }

    private void shot()
    {
        audioSource.PlayOneShot(Enshot);
        if (gunType == GunType.HandGun) SelectShot(gameObject, 750);
        if (gunType == GunType.ShotGun)
        {
            for(int i = 0; i < 7; i++)
            {
                SelectShot(gameObject, 750);
            }   
        }
        if (gunType == GunType.AssaultRifle) SelectShot(gameObject, 1000);
        time = 0;
        if(assaultCount > 15)
        {
            time = -4.0f;
            assaultCount = 0;
        }
    }

    private void SelectShot(GameObject launcher, int Speed)
    {
        Vector3 force = launcher.transform.forward * Speed;
        float disperse = 80f;
        Vector3 shotgun_force = new Vector3(Random.Range(disperse, -disperse), Random.Range(disperse, -disperse), Random.Range(disperse, -disperse));
        var pos = launcher.transform.position;
        var rot = launcher.transform.rotation;

        GameObject Copy_Shot = Instantiate(Original_Bullet, pos, rot) as GameObject;
        Copy_Shot.tag = "EnemyShot";
        Copy_Shot.name = "EnemyShot";
        if (gunType == GunType.ShotGun) Copy_Shot.GetComponent<Rigidbody>().AddForce(shotgun_force);
        Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        Destroy(Copy_Shot, 3.0f);
    }


    private void LookEnemy()
    {
        // ターゲットへの向きベクトル計算
        var dir = PlayerCenter.transform.position - this.transform.position;

        // ターゲットの方向への回転
        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
        // 回転補正
        var offsetRotation = Quaternion.FromToRotation(Vector3.forward, Vector3.forward);

        // 回転補正→ターゲット方向への回転の順に、自身の向きを操作する
        this.transform.rotation = lookAtRotation * offsetRotation;
    }
}
