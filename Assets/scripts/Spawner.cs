using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject MiniBoss;

    private void Start()
    {
        Enemy = GameObject.Find("Enemy");
        MiniBoss = GameObject.Find("MiniBoss");
        GetChildren(this.gameObject);
        if (this.gameObject.name == "Spawner")
        {         
            Destroy(gameObject, 2.0f);
        }
        else if(this.gameObject.name == "EnemySpawner") EnemySpawn();
        else if (this.gameObject.name == "MiniBossSpawner") MiniBossSpawn();
        //if (this.gameObject.name == "Enemy" || this.gameObject.name == "MiniBoss") Enemy.SetActive(false);
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
    private void MiniBossSpawn()
    {
        Vector3 force = transform.forward;
        var pos = transform.position;
        var rot = transform.rotation;

        GameObject miniBoss = Instantiate(MiniBoss, pos, rot) as GameObject;
        miniBoss.tag = "MiniBoss";
        miniBoss.name = "MiniBoss_copy";
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
