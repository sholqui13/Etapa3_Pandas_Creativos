using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public float fallDistance = 3f;
    public float fallDuration = 0.5f;
    public float delayBeforeReset = 2f;

    public SemaforoColor semaforo; // Referencia al script del semáforo

    private List<Transform> tiles = new List<Transform>();
    private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();

    private string ultimoColorProcesado = "";

    void Start()
    {
        foreach (Transform child in transform)
        {
            tiles.Add(child);
            originalPositions[child] = child.position;
        }

        // Procesar el color inicial del semáforo
        if (semaforo != null)
        {
            ultimoColorProcesado = semaforo.ObtenerNombreColor();
            StartCoroutine(ActivatePlatform(ultimoColorProcesado));
        }
    }

    void Update()
    {
        if (semaforo == null) return;

        string colorActual = semaforo.ObtenerNombreColor();

        // Detectar cambio de color
        if (colorActual != ultimoColorProcesado)
        {
            ultimoColorProcesado = colorActual;
            StartCoroutine(ActivatePlatform(colorActual));
        }
    }

    public IEnumerator ActivatePlatform(string safeColor)
    {
        List<Transform> toDrop = new List<Transform>();

        foreach (Transform tile in tiles)
        {
            string tileColor = tile.tag; // Usa la Tag para identificar el color

            if (!tileColor.Equals(safeColor, System.StringComparison.OrdinalIgnoreCase))
            {
                toDrop.Add(tile);
            }
        }

        // Bajar los cubos incorrectos
        foreach (Transform tile in toDrop)
        {
            StartCoroutine(MoveTile(tile, originalPositions[tile], originalPositions[tile] - new Vector3(0, fallDistance, 0), fallDuration));
        }

        yield return new WaitForSeconds(delayBeforeReset);

        // Subir de nuevo los cubos
        foreach (Transform tile in toDrop)
        {
            StartCoroutine(MoveTile(tile, tile.position, originalPositions[tile], fallDuration));
        }
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
