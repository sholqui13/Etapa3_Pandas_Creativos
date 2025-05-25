using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform jugador;
    public float alturaCaida = -5f;

    private bool juegoTerminado = false;

    void Update()
    {
        if (juegoTerminado) return;

        if (jugador.position.y < alturaCaida)
        {
            Debug.Log("El jugador cay� al agua. Fin del juego.");
            FinDelJuego(false);
        }
    }

    public void FinDelJuego(bool victoriaPorRondas)
    {
        juegoTerminado = true;

        if (victoriaPorRondas)
        {
            Debug.Log("�Victoria! Sobreviviste a los 5 cambios.");
        }
        else
        {
            Debug.Log("�Derrota! Has ca�do al agua.");
        }

        // Reiniciar escena despu�s de unos segundos
        Invoke("ReiniciarJuego", 3f);
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
