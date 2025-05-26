using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Victoria : MonoBehaviour
{
    public TMP_Text textPuntos;
    public GameObject panelVictoria;

    public void MostrarVictoria(int puntos = 0)
    {
        Time.timeScale = 0f;

        if (panelVictoria != null)
            panelVictoria.SetActive(true);

        if (textPuntos != null)
            textPuntos.text = "¡Ganaste! Puntos: " + puntos;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}
