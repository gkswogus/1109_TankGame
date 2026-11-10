using UnityEngine;
using UnityEngine.AI;

public class EnermyMove : MonoBehaviour
{
    [Header("추적 대상")]
    public Transform player;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player == null) return;

        agent.SetDestination(player.position);
    }
}
