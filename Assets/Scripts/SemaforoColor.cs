using UnityEngine;

public class SemaforoColor : MonoBehaviour
{
    [Header("Materiales de colores (9)")]
    public Material[] colores = new Material[9];

    [Header("Renderer del panel del semáforo")]
    public Renderer panelRenderer;

    [Header("Sonido de cambio de color")]
    public AudioClip sonidoCambio;

    private AudioSource audioSource;
    [HideInInspector] public int colorActualIndex;

    private int ultimoColorIndex = -1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    /// <summary>
    /// Cambia el color de manera controlada desde PlatformManager
    /// </summary>
    public void CambiarColorAleatorio()
    {
        if (colores.Length == 0 || panelRenderer == null) return;

        int nuevoColorIndex;
        do
        {
            nuevoColorIndex = Random.Range(0, colores.Length);
        } while (nuevoColorIndex == ultimoColorIndex && colores.Length > 1);

        colorActualIndex = nuevoColorIndex;
        ultimoColorIndex = colorActualIndex;

        panelRenderer.material = colores[colorActualIndex];

        if (sonidoCambio != null)
        {
            audioSource.PlayOneShot(sonidoCambio);
        }

        Debug.Log("Nuevo color: " + colores[colorActualIndex].name);
    }

    public string ObtenerNombreColor()
    {
        if (colores.Length == 0) return "Sin color";
        return colores[colorActualIndex].name;
    }

    public Color ObtenerColorActual()
    {
        if (colores.Length == 0) return Color.white;
        return colores[colorActualIndex].color;
    }
}
