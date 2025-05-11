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

    private float tiempoCambio = 8.0f;
    private float temporizador = 0f;

    private int ultimoColorIndex = -1;

    void Start()
    {
        // Obtener o agregar componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asegurarse que no se reproduzca automáticamente
        audioSource.playOnAwake = false;

        CambiarColorAleatorio();
    }

    void Update()
    {
        temporizador += Time.deltaTime;
        if (temporizador >= tiempoCambio)
        {
            CambiarColorAleatorio();
            temporizador = 0;
        }
    }

    public void CambiarColorAleatorio()
    {
        if (colores.Length == 0 || panelRenderer == null) return;

        // Elegir color aleatorio diferente al anterior
        int nuevoColorIndex;
        do
        {
            nuevoColorIndex = Random.Range(0, colores.Length);
        } while (nuevoColorIndex == ultimoColorIndex && colores.Length > 1);

        colorActualIndex = nuevoColorIndex;
        ultimoColorIndex = colorActualIndex;

        // Asignar nuevo material al panel
        panelRenderer.material = colores[colorActualIndex];

        // Reproducir sonido
        if (sonidoCambio != null)
        {
            audioSource.PlayOneShot(sonidoCambio);
        }

        Debug.Log("Color actual: " + colores[colorActualIndex].name);
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
