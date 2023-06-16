using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HpText;
    public int HP;

    private void Start()
    {
        HP = 15;
    }

    private void Update() 
    {
        HpText.text = "HP : " + HP;
        if (HP <= 0) SceneManager.LoadScene("EndScene");
    }

    public void Damage(in int damage)
    {
        HP = HP - damage; 
    }

    public void Heal(in int heal)
    {
        HP = HP + heal;
    }
}
