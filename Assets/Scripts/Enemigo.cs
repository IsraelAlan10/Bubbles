using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;
    public GameObject gota;
    public Boss boss;

    private void Start()
    {
        animator = GetComponent<Animator>();
        boss = GetComponent<Boss>();
    }
    public void TomarDano(float dano)
    {
        vida -= dano;

        if(vida <= 0)
        {
            Muerte();
        }
    }
    public void Muerte()
    {
        animator.SetTrigger("muerte");
        gota.SetActive(true);
        boss.enabled = false;
    }
}
