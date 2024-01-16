using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;


    public void OptionsPanel() {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }
    public void Return() {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }
    public void MainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Inicio");
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void Creditos()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Creditos");
    }
}
