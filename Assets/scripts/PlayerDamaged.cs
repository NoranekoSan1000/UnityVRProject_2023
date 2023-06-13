using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] private HPManager hpManager;

    [SerializeField] private AudioClip SE_Damaged;
    AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "EnemyShot") return;
        hpManager.Damage(1);
        audioSource.PlayOneShot(SE_Damaged);
        Destroy(other.gameObject);
    }
}
