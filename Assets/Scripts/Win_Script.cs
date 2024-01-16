using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win_Script : MonoBehaviour
{
    public Text puntaje1;
    public Text puntaje2;
    public GameObject panel_win;
    public GameObject imageWin;
    
    private int totalPuntaje2;
    private void Start()
    {
        totalPuntaje2 = transform.childCount;
        panel_win.GetComponent<GameObject>();
        imageWin.GetComponent<GameObject>();
    }
    private void Update()
    {
        Win();
        puntaje2.text = totalPuntaje2.ToString();
        puntaje1.text = transform.childCount.ToString();
    }
    public void Win()
    {
        if (transform.childCount == 0)
        {
            Time.timeScale = 0;
            panel_win.SetActive(true);
            imageWin.SetActive(true);
        }

    }
}
