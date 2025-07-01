using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    RaycastHit hit;
    CinemachineImpulseSource impulseSource;
    
    [SerializeField] LayerMask interactionLayer;
    [SerializeField] ParticleSystem muzzleFlash;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();    
    }

    public void Shoot(WeaponSO weaponSO)
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayer, QueryTriggerInteraction.Ignore))
        {
            muzzleFlash.Play();
            impulseSource.GenerateImpulse();
            Instantiate(weaponSO.HitVfxPrefab, hit.point, quaternion.identity);
            Health enemyHealth = hit.collider.GetComponent<Health>();
            enemyHealth?.takeDamage(weaponSO.Damage); // Changes damage according to the scriptable attached
            // starterAssetsInputs.ShootInput(false);
            //if (enemyHealth != null) 
            //{ 
            //    enemyHealth.takeDamage(gunDamage);
            //    starterAssetsInputs.ShootInput(false);
            //}
        }
    }
}
