using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float dano;
    [SerializeField] public float tiempoBase;
    private float tiempoSeguir;

    public LifeBar lifeBar;
    private Transform jugador;
    
    private void Start()
    {
        tiempoSeguir = tiempoBase;
        lifeBar = FindObjectOfType<LifeBar>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
        tiempoSeguir -= Time.deltaTime;
        Girar(jugador.position);
        if (tiempoSeguir <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Girar(Vector3 objetivo)
    {
        if (objetivo.x > transform.position.x)
        {
            transform.localScale = new Vector2(5, 5);
        }
        else
        {
            transform.localScale = new Vector2(-5, 5);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lifeBar.vidas = lifeBar.vidas - dano;
            lifeBar.sliderVidas.value = lifeBar.vidas;
            lifeBar.animator.Play("Hit");
            Destroy(gameObject);
            if (lifeBar.vidas <= 0)
            {
                lifeBar.animator.Play("Hit");
                lifeBar.Invoke("spriteEnabled", 0.3f);
                lifeBar.Invoke("ChangeScene", 0.5f);
            }
        }
        if (collision.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }

    }
}

