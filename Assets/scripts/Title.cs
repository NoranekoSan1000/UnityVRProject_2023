using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText_1;
    [SerializeField] private GameObject MoveInput;
    [SerializeField] private ReSetTrackingSpace resetTrackingSpace;
    [SerializeField] private OVRScreenFade ovrScreenFade;

    [SerializeField] private AudioClip SE_HitTarget;
    AudioSource audioSource;

    private bool GameStart = false;
    private float Timer = 0;

    private void Start()
    {
        MoveInput.SetActive(false);
        GameStart = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            titleText_1.text = "Bボタン、またはYボタンを押して\n銃を拾い、目の前の球体を撃つと\nスタートします。";
            resetTrackingSpace.FirstStickInput = true;
            MoveInput.SetActive(true);
        }
        if (GameStart)
        {
            Timer += Time.deltaTime;
            ovrScreenFade.FadeOut();
        }
        if (Timer > 2.0f)
        {
            SceneManager.LoadScene("GameScene");
            Timer = 0;
            GameStart = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerShot") return;
        if (!GameStart)
        {
            GameStart = true;
            audioSource.PlayOneShot(SE_HitTarget);
        }
    }

}
