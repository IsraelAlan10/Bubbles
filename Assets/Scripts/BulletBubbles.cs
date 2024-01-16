using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBubbles : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float dano;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Scraps")) {
            collision.GetComponent<EnemigoScraps>().Dano(dano);
            Debug.Log("Daño Scraps");
            Destroy(gameObject);
        }
        if(collision.CompareTag("Boss"))
        {
            collision.GetComponent<Enemigo>().TomarDano(dano);
            Destroy(gameObject);
        }
        if(collision.CompareTag("Enemigo"))  {
            Destroy(gameObject);
        }
    }
}
