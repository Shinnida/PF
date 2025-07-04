using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private bool pausa=false;
    public TMP_Text Monedas_text;
    private int monedas;
    private string scene;
    [Header("Player")]

    public PlayerController playerController;

    private void Start()
    {
        ActualizarMonedas(monedas);
    }
    private void OnDestroy()
    {
        if (scene == "Game")
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void Pausa()
    {
        if (pausa)
        {
            Time.timeScale = 1.0f;
            pausa = false;
        }
        else
        {
            Time.timeScale = 0f;
            pausa = true;
        }
    }
    public void CargarScena(string scene)
    {
        Time.timeScale = 1;
        this.scene = scene;
        playerController.SavePosition();

        SceneManager.LoadScene(scene);
    }
    public void ActualizarMonedas(int monedas)
    {
        this.monedas += monedas;
        Monedas_text.text = monedas.ToString();
    }
}
