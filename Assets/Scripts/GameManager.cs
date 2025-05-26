using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform jugador;
    public float alturaCaida = -0.002f;

    [Header("Pantallas UI")]
    public GameObject PantallaVictoria;
    public GameObject PantallaDerrota;
    public GameObject PantallaFinal;

    public float tiempoAntesPantallaFinal = 5f; // Tiempo de espera antes de mostrar la pantalla final

    private bool juegoTerminado = false;

    void Update()
    {
        if (juegoTerminado) return;

        // Verificar si el jugador cayó al agua
        if (jugador.position.y < alturaCaida)
        {
            Debug.Log("El jugador cayó al agua. Fin del juego.");
            FinDelJuego(false);
        }
    }

    public void FinDelJuego(bool victoriaPorRondas)
    {
        juegoTerminado = true;

        if (victoriaPorRondas)
        {
            Debug.Log("¡Victoria! Sobreviviste a los 5 cambios.");
            PantallaVictoria.SetActive(true);  // Mostrar Canvas Victoria
        }
        else
        {
            Debug.Log("¡Derrota! Has caído al agua.");
            PantallaDerrota.SetActive(true);   // Mostrar Canvas Derrota
        }

        // Después de unos segundos, mostrar pantalla final
        Invoke(nameof(MostrarPantallaFinal), tiempoAntesPantallaFinal);
    }

    void MostrarPantallaFinal()
    {
        PantallaVictoria.SetActive(false);
        PantallaDerrota.SetActive(false);

        PantallaFinal.SetActive(true); // Mostrar Canvas Final con botones
        Time.timeScale = 0f; // Pausar el juego
    }

    // Función para el botón de "Volver a Jugar"
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // Quitar la pausa
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Función para el botón de "Salir"
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
