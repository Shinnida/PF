using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NuevaPartida()
    {
        SceneManager.LoadScene("Nivel1"); // Cambia por el nombre de tu primera escena jugable
    }

    public void CargarPartida()
    {
        Debug.Log("Función de cargar partida aún no implementada.");
    }

    public void Opciones()
    {
        Debug.Log("Abrir menú de opciones (implementarlo luego).");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
