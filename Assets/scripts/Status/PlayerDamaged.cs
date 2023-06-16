using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] private HPManager hpManager;

    [SerializeField] private AudioClip SE_Damaged;
    AudioSource audioSource;

    private float coolTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (coolTime >= 0) coolTime -= Time.deltaTime;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndArea") SceneManager.LoadScene("EndScene");
        if (other.tag != "EnemyShot") return;
        if (coolTime > 0) return;
        hpManager.Damage(1);
        coolTime = 1.5f;
        audioSource.PlayOneShot(SE_Damaged);
        Destroy(other.gameObject);
    }
}
