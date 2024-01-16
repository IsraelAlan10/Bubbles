using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volver_Behaviour : StateMachineBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private Vector3 puntoInicial;
    private Enemigo2D serum;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        serum = animator.gameObject.GetComponent<Enemigo2D>();
        puntoInicial = serum.puntoInicial;
        serum.puntoInicial = puntoInicial;

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);
        serum.Girar(puntoInicial);
        if(animator.transform.position == puntoInicial) {
            animator.SetTrigger("Llego");
        }
    }
}
