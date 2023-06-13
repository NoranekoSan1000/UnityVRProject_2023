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
        // �^�[�Q�b�g�ւ̌����x�N�g���v�Z
        var dir = PlayerCenter.transform.position - this.transform.position;

        // �^�[�Q�b�g�̕����ւ̉�]
        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
        // ��]�␳
        var offsetRotation = Quaternion.FromToRotation(Vector3.forward, Vector3.forward);

        // ��]�␳���^�[�Q�b�g�����ւ̉�]�̏��ɁA���g�̌����𑀍삷��
        this.transform.rotation = lookAtRotation * offsetRotation;
    }
}
