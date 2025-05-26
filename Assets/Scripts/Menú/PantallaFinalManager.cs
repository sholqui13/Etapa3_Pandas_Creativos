using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaFinalManager : MonoBehaviour
{
    public GameObject pantallaFinalPanel;    // Panel UI que contiene toda la pantalla final
    public Text mensajeTexto;                 // Texto que mostrará "¡Victoria!" o "¡Derrota!"

    void Start()
    {
        // Asegurarse que el panel está oculto al inicio
        pantallaFinalPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Mostrar pantalla final, recibe si fue victoria o no
    public void MostrarPantallaFinal(bool victoria)
    {
        pantallaFinalPanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego

        if (victoria)
            mensajeTexto.text = "¡Victoria! 🎉";
        else
            mensajeTexto.text = "¡Derrota! 😞";
    }

    // Botón para jugar de nuevo
    public void JugarDeNuevo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Botón para salir del juego
    public void SalirDelJuego()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
