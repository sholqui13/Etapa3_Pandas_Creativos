using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SaltoConGiro : MonoBehaviour
{
    public float fuerzaDeSalto = 5f;
    public float velocidadRotacion = 720f; // Grados por segundo
    public ParticleSystem efectoEstrella;

    private Rigidbody rb;
    private bool puedeSaltar = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            SaltarConEfecto();
        }
    }

    void SaltarConEfecto()
    {
        // Aplica la fuerza de salto
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, fuerzaDeSalto, rb.linearVelocity.z);


        // Inicia la rotación en el aire
        StartCoroutine(GiroEnElAire());

        // Activa el efecto de estrella si está asignado
        if (efectoEstrella != null)
        {
            efectoEstrella.Play();
        }

        puedeSaltar = false;
    }

    IEnumerator GiroEnElAire()
    {
        float duracion = 0.5f;
        float tiempoPasado = 0f;

        while (tiempoPasado < duracion)
        {
            float rotacion = velocidadRotacion * Time.deltaTime;
            transform.Rotate(Vector3.up, rotacion);
            tiempoPasado += Time.deltaTime;
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Habilita el salto al tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            puedeSaltar = true;
        }
    }
}

