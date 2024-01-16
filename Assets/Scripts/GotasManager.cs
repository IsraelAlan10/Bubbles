using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GotasManager : MonoBehaviour
{
    public Image imageGotas;
    public GameObject transition;
    public Text puntaje1;
    public Text puntaje2;
 
    private int totalPuntaje2;
    private void Start()
    {
        totalPuntaje2 = transform.childCount;
    }
    private void Update()
    {
        GotasCollected();
        puntaje2.text = totalPuntaje2.ToString();
        puntaje1.text = transform.childCount.ToString();
    }
    public void GotasCollected() {
        if (transform.childCount == 0) {
            imageGotas.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("ChangeScene", 2);
        }
        
    }
    void ChangeScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
