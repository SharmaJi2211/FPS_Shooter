using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float waitForSeconds = 5f;
    [SerializeField] Transform spawnPoint;

    PlayerHealth player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(enemySpawner());        
    }

    IEnumerator enemySpawner()
    {
        while (player)
        {
            Instantiate(enemyPrefab, spawnPoint.position, transform.rotation);    
            yield return new WaitForSeconds(waitForSeconds);
        }
    }
}
