using UnityEngine;

public class WeaponPickUp : BasePickUp
{
    [SerializeField] WeaponSO WeaponSO;
    [SerializeField] float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);    
    }

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(WeaponSO);
    }
}
