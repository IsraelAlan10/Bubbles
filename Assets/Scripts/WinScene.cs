using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    public GameObject winPanel;

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Inicio");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
