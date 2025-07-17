using StarterAssets;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1 , 10)]
    [SerializeField] int maxHealth = 10;
    [SerializeField] CinemachineCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] healthBar;
    [SerializeField] GameObject gameOverContainer;

    int currentHealth;
    int deathCameraPriority = 20;
    void Awake()
    {
        currentHealth = maxHealth;
        adjustHealthBar();
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        adjustHealthBar();

        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        weaponCamera.parent = null; // Weapon camera is being set to null, hence itll not throw any error when player dies.
        deathVirtualCamera.Priority = deathCameraPriority;
        gameOverContainer.SetActive(true);
        StarterAssetsInputs starterInput = FindFirstObjectByType<StarterAssetsInputs>();
        starterInput.SetCursorState(false);
        Destroy(this.gameObject);
    }

    void adjustHealthBar()
    {
        for (int i = 0; i < healthBar.Length; i++)
        {
            if (i < currentHealth)
            {
                healthBar[i].gameObject.SetActive(true);
            }
            else
            {
                healthBar[i].gameObject.SetActive(false);
            }
        }
    }
}
