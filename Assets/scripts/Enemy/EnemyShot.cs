using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject PlayerCenter;
    [SerializeField] private GameObject Original_Bullet;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2.0f) shot();
    }

    private void shot()
    {
        SelectShot(gameObject, 500);
        time = 0;
    }

    private void SelectShot(GameObject launcher, int Speed)
    {
        Vector3 force = launcher.transform.forward * Speed;
        var pos = launcher.transform.position;
        var rot = launcher.transform.rotation;

        GameObject Copy_Shot = Instantiate(Original_Bullet, pos, rot) as GameObject;
        Copy_Shot.tag = "EnemyShot";
        Copy_Shot.name = "EnemyShot";
        Copy_Shot.GetComponent<Rigidbody>().AddForce(force);
        Destroy(Copy_Shot, 3.0f);
    }


    private void LookEnemy()
    {
        var CharaDirection = PlayerCenter.transform.position - this.transform.position;
        var lookRotation = Quaternion.LookRotation(CharaDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1.5f);
    }
}
