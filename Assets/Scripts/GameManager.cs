using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GameManager : MonoBehaviour
{
    public Transform jugador;
    public float alturaCaida = -5f;
 
    public GameObject pantallaVictoria;
    public GameObject pantallaDerrota;
    public GameObject pantallaFinal; // 🎯 Pantalla final
 
    private bool juegoTerminado = false;
 
    public float tiempoPantallaFinal = 3f; // ⏱ Tiempo antes de mostrar la pantalla final
 
    void Update()
    {
        if (juegoTerminado) return;
 
        // Detectar si el jugador cae al agua
        if (jugador.position.y < alturaCaida)
        {
            Debug.Log("El jugador cayó al agua.");
            FinDelJuego(false);
        }
    }
 
    public void FinDelJuego(bool victoriaPorRondas)
    {
        juegoTerminado = true;
 
        if (victoriaPorRondas)
        {
            Debug.Log("¡Victoria!");
            pantallaVictoria.SetActive(true); // ✅ Muestra victoria
        }
        else
        {
            Debug.Log("¡Derrota!");
            pantallaDerrota.SetActive(true); // ❌ Muestra derrota
        }
 
        // ⏳ Después de unos segundos, mostrar la pantalla final
        Invoke("MostrarPantallaFinal", tiempoPantallaFinal);
    }
 
    void MostrarPantallaFinal()
    {
        pantallaVictoria.SetActive(false);
        pantallaDerrota.SetActive(false);
 
        pantallaFinal.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego (opcional)
    }
 
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f; // Quita la pausa
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}