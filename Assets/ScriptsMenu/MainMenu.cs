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
        Debug.Log("Funci�n de cargar partida a�n no implementada.");
    }

    public void Opciones()
    {
        Debug.Log("Abrir men� de opciones (implementarlo luego).");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
