using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateCuerpo : MonoBehaviour
{
    [SerializeField] private Transform ControladorAtaque;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float danoGolpe;

    [SerializeField] private float tiempoEntreAtaques;
    private float tiempoSiguienteAtaque;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if( tiempoSiguienteAtaque > 0 )
        {
            tiempoSiguienteAtaque-= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }
    private void Golpe()
    {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControladorAtaque.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Boss")){
                colisionador.transform.GetComponent<Enemigo>().TomarDano(danoGolpe);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorAtaque.position, radioGolpe);
    }
}
