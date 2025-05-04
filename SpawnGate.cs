using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnTime = 5f;
    
    [SerializeField] Transform spawnPoint;

    PlayerHealth player;
    void Start()
    {
        player = FindAnyObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine(){
        while(player){
            GameObject robot = Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
        Debug.Log($"[SpawnGate] Spawned: {robot.name}");
        yield return new WaitForSeconds(spawnTime);
        }
    }
}
