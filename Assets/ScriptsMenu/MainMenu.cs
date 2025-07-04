using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CargarScena(string scene)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(scene);
    }
    public void CargarScena()
    {
        SceneManager.LoadScene("Game");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
