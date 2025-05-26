using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public float fallDistance = 0.5f;
    public float fallDuration = 1f;
    public float delayBeforeFall = 5f;
    public float delayBeforeReset = 2f;

    public SemaforoColor semaforo;

    private List<Transform> tiles = new List<Transform>();
    private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();

    private string ultimoColorProcesado = "";

    private int cambioColorCount = 0;
    public int maxCambiosDeColor = 5;

    private bool juegoActivo = true;

    void Start()
    {
        foreach (Transform child in transform)
        {
            tiles.Add(child);
            originalPositions[child] = child.position;
        }

        StartCoroutine(IniciarSecuencia());
    }

    private IEnumerator IniciarSecuencia()
    {
        // Tiempo inicial para que los jugadores se posicionen
        Debug.Log("Preparados... 6 segundos para comenzar.");
        yield return new WaitForSeconds(6f);

        while (juegoActivo)
        {
            // Cambiar color
            semaforo.CambiarColorAleatorio();
            string colorSeguro = semaforo.ObtenerNombreColor();
            Debug.Log("Color seguro: " + colorSeguro);

            // Esperar antes de que caigan las plataformas incorrectas
            yield return new WaitForSeconds(delayBeforeFall);

            // Activar caída de plataformas incorrectas
            yield return StartCoroutine(ActivatePlatform(colorSeguro));

            cambioColorCount++;

            if (cambioColorCount >= maxCambiosDeColor)
            {
                Debug.Log("Juego finalizado por límite de cambios de color.");
                juegoActivo = false;
                // Aquí puedes activar pantalla de victoria o terminar el juego.
            }
        }
    }

    public IEnumerator ActivatePlatform(string safeColor)
    {
        List<Transform> toDrop = new List<Transform>();

        foreach (Transform tile in tiles)
        {
            string tileColor = tile.tag;

            if (!tileColor.Equals(safeColor, System.StringComparison.OrdinalIgnoreCase))
            {
                toDrop.Add(tile);
            }
        }

        // Bajar plataformas incorrectas
        foreach (Transform tile in toDrop)
        {
            StartCoroutine(MoveTile(tile, originalPositions[tile], originalPositions[tile] - new Vector3(0, fallDistance, 0), fallDuration));
        }

        yield return new WaitForSeconds(delayBeforeReset);

        // Subir plataformas nuevamente
        foreach (Transform tile in toDrop)
        {
            StartCoroutine(MoveTile(tile, tile.position, originalPositions[tile], fallDuration));
        }

        // Al finalizar el reseteo, el semáforo cambiará en el siguiente ciclo del Coroutine IniciarSecuencia()
    }

    private IEnumerator MoveTile(Transform tile, Vector3 startPos, Vector3 endPos, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            tile.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        tile.position = endPos;
    }
}
