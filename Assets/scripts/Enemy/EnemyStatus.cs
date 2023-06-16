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

    [SerializeField] private int hp;
    [SerializeField] private int score;

    private bool alive; 
    private float soundCT = 0;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        soundCT -= Time.deltaTime;
        transform.position = transform.parent.gameObject.transform.position;
        LookEnemy();
        if (hp <= 0) dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerShot") return;
            hp -= 1;
        if (hp > 0 && soundCT < 0) audioSource.PlayOneShot(SE_HitTarget);
        soundCT = 0.2f;
        Destroy(other.gameObject);
    }

    private void dead()
    {
        if(alive) present();
        Destroy(transform.parent.gameObject,0.1f);
    }
    private void present()
    {
        _scoreManager.AddScore(score);
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