using UnityEngine;
using UnityEngine.Video;

public class Enemigo2D : MonoBehaviour
{
    public Transform jugador;
    public Vector3 puntoInicial;
    public LifeBar lifeBar;
    public float damageSerum;
    public float damageRocket;
    private GotasManager gotas;
    
    [SerializeField] private float distancia;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gotas = FindObjectOfType<GotasManager>();
        puntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeBar = FindObjectOfType<LifeBar>();
    }
    private void Update() {
        distancia = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("Distancia", distancia);
        if (gotas.transform.childCount == 0) {
            Destroy(gameObject);
        }
    }
    public void Girar(Vector3 objetivo) {
        if(transform.position.x < objetivo.x){
            spriteRenderer.flipX = true;
        }
        else {
            spriteRenderer.flipX = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.SetTrigger("Atack");
            animator.SetTrigger("Attack");
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Serum"))
            {
                lifeBar.vidas = lifeBar.vidas - damageSerum;
                lifeBar.sliderVidas.value = lifeBar.vidas;
                lifeBar.animator.Play("Hit");
                if (lifeBar.vidas <= 0)
                {
                    lifeBar.animator.Play("Hit");
                    lifeBar.Invoke("spriteEnabled", 0.3f);
                    lifeBar.Invoke("ChangeScene", 1.0f);
                }
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Atack_rocket"))
            {
                lifeBar.vidas = lifeBar.vidas - damageRocket;
                lifeBar.sliderVidas.value = lifeBar.vidas;
                lifeBar.animator.Play("Hit");
                if (lifeBar.vidas <= 0)
                {
                    lifeBar.animator.Play("Hit");
                    lifeBar.Invoke("spriteEnabled", 0.3f);
                    lifeBar.Invoke("ChangeScene", 1.0f);
                }
            }
        }
    }

}
