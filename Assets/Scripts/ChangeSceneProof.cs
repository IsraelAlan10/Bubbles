using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneProof : MonoBehaviour
{
    
    public void Juego()
    {
        Invoke("Level1", 0.5f);
    }

   void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }
   public void ChangeScene()
    {
        SceneManager.LoadScene("ModoJuego");
    }
    public void Inicial()
    {
        SceneManager.LoadScene("Inicial");
    }
    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
