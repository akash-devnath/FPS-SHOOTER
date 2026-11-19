using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class RobotEnemy : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent navAgent;
    const string PLAYER_TAG = "Player";

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
    }

    
    void Update()
    {
        if (!player) return;
        navAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_TAG))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
