using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadCarrera = 8f;
    public float fuerzaSalto = 7f;
    public float gravedadExtra = 2f;
    private bool enSuelo;

    private CharacterController controller;
    private Vector3 movimiento;
  

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Mover();
        Saltar();
    }

    void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * horizontal + transform.forward * vertical;

        // Alternar entre caminar y correr
        float velocidadFinal = Input.GetKey(KeyCode.LeftShift) ? velocidadCarrera : velocidad;
        movimiento.x = direccion.x * velocidadFinal;
        movimiento.z = direccion.z * velocidadFinal;

        // Aplicar gravedad manualmente
        if (!controller.isGrounded)
            movimiento.y += Physics.gravity.y * gravedadExtra * Time.deltaTime;

        controller.Move(movimiento * Time.deltaTime);
    }

    void Saltar()
    {
        enSuelo = controller.isGrounded; // Asignamos el valor correcto

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            movimiento.y = fuerzaSalto;
        }
    }
}
