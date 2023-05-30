using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TargetStatus : MonoBehaviour
{

    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TimeManager _timeManager;
    public AudioClip SE_HitTarget;
    AudioSource audioSource;

    Vector3 FirstPos;

    // Start is called before the first frame update
    void Start()
    {
        FirstPos = this.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _timeManager.TimerActive = true;
        audioSource.PlayOneShot(SE_HitTarget);
        this.transform.position = new Vector3(FirstPos.x + Random.Range(-6, 6), FirstPos.y + Random.Range(-2, 2), FirstPos.z);
        if(_timeManager.timer > 0) _scoreManager.AddScore(1);
    }
}