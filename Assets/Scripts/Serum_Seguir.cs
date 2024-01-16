using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Serum_Seguir : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] public float tiempoBase;
    private float tiempoSeguir;
    private Transform jugador;
    private Enemigo2D serum;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempoSeguir = tiempoBase;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        serum = animator.gameObject.GetComponent<Enemigo2D>();
    }       

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, jugador.position, velocidadMovimiento * Time.deltaTime);
        serum.Girar(jugador.position);
        tiempoSeguir -= Time.deltaTime;
        if (tiempoSeguir <= 0) {
            animator.SetTrigger("Volver");
        }
    }

 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
