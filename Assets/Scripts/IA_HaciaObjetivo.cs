using UnityEngine;
using UnityEngine.AI;

public class IA_HaciaObjetivo : MonoBehaviour
{
    public Transform objetivo;  // El hongo o estructura

    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (objetivo != null)
        {
            agente.SetDestination(objetivo.position);
        }
    }
}
