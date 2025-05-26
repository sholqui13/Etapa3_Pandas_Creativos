using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        Debug.Log("Reiniciando nivel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VolverAlMenu()
    {
        Debug.Log("Volviendo al men�");
        SceneManager.LoadScene("Menu"); // Cambia esto por el nombre de tu escena de men�
    }
}
