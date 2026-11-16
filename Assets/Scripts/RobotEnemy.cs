using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class RobotEnemy : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent navAgent;
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        navAgent.SetDestination(player.transform.position);
    }
}
