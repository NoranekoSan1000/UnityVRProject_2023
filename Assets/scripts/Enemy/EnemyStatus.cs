using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private GameObject PlayerCenter;

    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private AudioClip SE_HitTarget;
    [SerializeField] private AudioClip SE_Dead;
    AudioSource audioSource;

    private bool alive;
    private int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        LookEnemy();
        if (hp <= 0) dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        hp -= 1;
        if (hp > 0) audioSource.PlayOneShot(SE_HitTarget);
        else audioSource.PlayOneShot(SE_Dead);
        if (other.tag == "PlayerShot") Destroy(other.gameObject);
    }

    private void dead()
    {
        if(alive) present();
        Destroy(transform.parent.gameObject,1f);
    }
    private void present()
    {
        _scoreManager.AddScore(100);
        alive = false;
    }

    private void LookEnemy()
    {
        var CharaDirection = PlayerCenter.transform.position - this.transform.position;
        CharaDirection.y = 0;
        var lookRotation = Quaternion.LookRotation(CharaDirection, Vector3.up);
        transform.parent.gameObject.transform.rotation = Quaternion.Lerp(transform.parent.gameObject.transform.rotation, lookRotation, 1.5f);
    }
}