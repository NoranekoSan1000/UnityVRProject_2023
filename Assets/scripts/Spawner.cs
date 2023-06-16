using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject MiniBoss;
    public GameObject ShotGunMan;
    public GameObject AssaultMan;

    private void Start()
    {
        Enemy = GameObject.Find("Enemy");
        MiniBoss = GameObject.Find("MiniBoss");
        ShotGunMan = GameObject.Find("ShotGunMan");
        AssaultMan = GameObject.Find("AssaultMan");

        GetChildren(this.gameObject);
        if (this.gameObject.name == "Spawner")
        {         
            Destroy(gameObject, 2.0f);
        }
        else if(this.gameObject.name == "EnemySpawner") EnemySpawn();
        else if (this.gameObject.name == "ShotGunManSpawner") ShotGunManSpawn();
        else if (this.gameObject.name == "AssaultManSpawner") AssaultManSpawn();
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
    private void ShotGunManSpawn()
    {
        Vector3 force = transform.forward;
        var pos = transform.position;
        var rot = transform.rotation;

        GameObject enemy = Instantiate(ShotGunMan, pos, rot) as GameObject;
        enemy.tag = "ShotGunMan";
        enemy.name = "ShotGunMan_copy";
    }
    private void AssaultManSpawn()
    {
        Vector3 force = transform.forward;
        var pos = transform.position;
        var rot = transform.rotation;

        GameObject enemy = Instantiate(AssaultMan, pos, rot) as GameObject;
        enemy.tag = "AssaultMan";
        enemy.name = "AssaultMan_copy";
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
