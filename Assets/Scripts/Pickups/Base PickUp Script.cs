using UnityEngine;

public abstract class BasePickUp : MonoBehaviour
{
    public const string Tag = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag) 
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickUp(activeWeapon);
            Destroy(this.gameObject);
        }
    }
    protected abstract void OnPickUp(ActiveWeapon activeWeapon); 
}
