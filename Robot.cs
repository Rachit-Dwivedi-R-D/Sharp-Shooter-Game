using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    const string PLAYER_STRING = "Player";
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        
    }

    
    void Update()
    {
        if(!player) return;
        agent.SetDestination(player.transform.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_STRING)){
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
