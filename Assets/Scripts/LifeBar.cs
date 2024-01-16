using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public GameObject transition;
    public Image imageLost;
    public Animator animator;
    [SerializeField] public float vidas;
    [SerializeField] public Slider sliderVidas;
    public SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Scraps"))
        {
            vidas--;
            sliderVidas.value = vidas;
            animator.Play("Hit");
            if(vidas <= 0)
            {
                transition.SetActive(true);
                imageLost.gameObject.SetActive(true);
                animator.Play("Hit");
                Invoke("spriteEnabled", 0.3f);
                
                Invoke("ChangeScene", 2.5f);
            }
        }
    }

    void Transition()
    {
        transition.SetActive(true);
        imageLost.gameObject.SetActive(true);
    }
    void spriteEnabled()
    {
        spriteRenderer.enabled = false;
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        sliderVidas.maxValue = vidas;
        sliderVidas.value = sliderVidas.maxValue;
    }
}
