using UnityEngine;

public class AmmoPickUp : BasePickUp
{
    [SerializeField] int ammoAmount = 100;
    [SerializeField] float rotationSpeed = 50f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.updateAmmoDisplay(ammoAmount);
    }
}
