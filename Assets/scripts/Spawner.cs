using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;

    private void Start()
    {
        Enemy = GameObject.Find("Enemy");
        GetChildren(this.gameObject);
        if (this.gameObject.name == "Spawner")
        {         
            Destroy(gameObject, 2.0f);
        }
        else EnemySpawn();
        if (this.gameObject.name == "Enemy") Enemy.SetActive(false);
    }

    private void EnemySpawn()
    {
        Vector3 force = transform.forward;
        var pos = transform.position;
        var rot = transform.rotation;

        GameObject enemy = Instantiate(Enemy, pos, rot) as GameObject;
        enemy.tag = "Enemy";
        enemy.name = "Enemy_copy";
    }

    void GetChildren(GameObject obj)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //éqóvëfÇ™Ç¢Ç»ÇØÇÍÇŒèIóπ
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            ob.gameObject.AddComponent<Spawner>();
            GetChildren(ob.gameObject);
        }
    }

}
