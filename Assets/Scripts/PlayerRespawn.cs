using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    public Animator animator;
    public Image imageLost;
    public GameObject transition;
    public SpriteRenderer spriteRenderer;

    public void Atack() {
        animator.Play("Serum");

    }
    public void PlayerDamage()
    {
        animator.Play("Hit");
        transition.SetActive(true);
        imageLost.gameObject.SetActive(true);
        Invoke("spriteEnabled", 0.3f);
        Invoke("LoadScene", 2.5f);
    }
    void spriteEnabled()
    {
        spriteRenderer.enabled = false;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
