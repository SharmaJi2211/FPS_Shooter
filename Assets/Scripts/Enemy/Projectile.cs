using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] GameObject projectileVFX;
    Rigidbody rigidBody;
    int damage;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        projectileShoot();
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }
    void projectileShoot()
    {
        rigidBody.linearVelocity = transform.forward * projectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player)
        {
            player.takeDamage(damage);
        }
        Instantiate(projectileVFX, transform.position, Quaternion.identity);    
        Destroy(this.gameObject);
    }
}
