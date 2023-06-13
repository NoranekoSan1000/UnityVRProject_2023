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
        LookEnemy();
           time += Time.deltaTime;
        if (time > 2.0f) shot();
    }

    private void shot()
    {
        SelectShot(gameObject, 750);
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
