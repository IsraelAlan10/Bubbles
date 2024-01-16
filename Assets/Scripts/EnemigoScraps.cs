using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScraps : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Dano(float dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            animator.SetTrigger("Collected");
            Invoke("Muerte",0.3f);

        }
    }
    public void Muerte()
    {
        Destroy(gameObject);
    }
}
