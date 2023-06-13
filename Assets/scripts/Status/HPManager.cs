using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HpText;
    public int HP;

    private void Start()
    {
        HP = 10;
    }

    private void Update() 
    {
        HpText.text = "HP : " + HP;    
    }

    public void Damage(in int damage)
    {
        HP = HP + damage; 
    }

    public void Heal(in int heal)
    {
        HP = HP + heal;
    }
}
