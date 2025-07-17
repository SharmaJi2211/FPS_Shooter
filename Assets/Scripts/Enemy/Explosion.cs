using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1f;
    [SerializeField] int damageAmount = 2;

    void Start()
    {
        explosion();    
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void explosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
            playerHealth?.takeDamage(damageAmount);
        }

        
    }
}
