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

    //  NUEVO: Referencia al script GameOver
    public GameOver gameOverManager;

    //  NUEVO: Altura límite para activar derrota
    public float alturaCaida = -5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Mover();
        Saltar();

        //  NUEVO: Detectar caída fuera del escenario
        if (transform.position.y < alturaCaida)
        {
            gameOverManager.MostrarGameOver();

            Debug.Log("¡Game Over activado!");

            this.enabled = false; // Detener controles del personaje
        }
    }

    void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * horizontal + transform.forward * vertical;

        float velocidadFinal = Input.GetKey(KeyCode.LeftShift) ? velocidadCarrera : velocidad;
        movimiento.x = direccion.x * velocidadFinal;
        movimiento.z = direccion.z * velocidadFinal;

        if (!controller.isGrounded)
            movimiento.y += Physics.gravity.y * gravedadExtra * Time.deltaTime;

        controller.Move(movimiento * Time.deltaTime);
    }

    void Saltar()
    {
        enSuelo = controller.isGrounded;

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            movimiento.y = fuerzaSalto;
        }
    }
}


