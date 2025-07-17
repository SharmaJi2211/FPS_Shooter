using System.Collections;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] Transform turretGun;
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float waitTime = 5f;
    [SerializeField] int damage = 2;

    PlayerHealth player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(spawnProjectile());
    }
    void Update()
    {
        transform.LookAt(playerPosition);
    }

    IEnumerator spawnProjectile()
    {
        while (player)
        {
            yield return new WaitForSeconds(waitTime);
            Projectile newprojectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newprojectile.transform.LookAt(playerPosition);
            newprojectile.Init(damage);
        }
    }
}
