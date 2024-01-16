using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    
    [SerializeField] private Transform controlDisparo;
    [SerializeField] private GameObject bala;
    private float velocidad = 7.0f;
    private float frenado = 15.0f;
    private float retraso = 15.0f;
    private float inicio = 30.0f;
    private Animator animator;
    private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > frenado && Vector2.Distance(transform.position, player.position) <= inicio) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
            animator.SetTrigger("Caminar");
        }
        if (Vector2.Distance(transform.position, player.position) < retraso)
        {
            animator.SetTrigger("Caminar");
            transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, player.position) < frenado && Vector2.Distance(transform.position, player.position) < retraso){
            transform.position = transform.position;
            animator.SetTrigger("iddle");
        }

        Girar(player.position);

        tiempo += Time.timeScale;

        if(tiempo >= 500 && Vector2.Distance(transform.position, player.position) <= inicio)
        {
            animator.SetTrigger("atack");
            Disparar();
            tiempo = 0;
        }
    }
    public void Girar(Vector3 objetivo) {
        if (objetivo.x > transform.position.x) {
            transform.localScale = new Vector2(1, 1);        
        }else
        {
            transform.localScale = new Vector2(-1, 1);
        }


    }
    private void Disparar()
    {
        Instantiate(bala, controlDisparo.position, Quaternion.identity);
    }

}
