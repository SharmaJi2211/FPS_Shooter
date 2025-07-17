using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] GameObject explosionVFX;
    GameManager gameManager;
    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.setEnemiesAmount(1);
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            selfDestruct();
        }
    }

    public void selfDestruct()
    {
            gameManager.setEnemiesAmount(-1);
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
    }
}
