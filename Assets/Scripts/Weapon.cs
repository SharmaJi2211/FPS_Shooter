using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    RaycastHit hit;
    StarterAssetsInputs starterAssetsInputs;
    Animator animator;
    const string SHOOT_ANIMATION = "Shooting";

    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVfxPrefab;
    [SerializeField] WeaponSO WeaponSo;

    //[SerializeField] int gunDamage;
    void Start()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponentInParent<Animator>();
    }
    void Update()
    {
        handleShooting();
    }

    void handleShooting()
    {
        if (!starterAssetsInputs.shoot == true) return;

        muzzleFlash.Play();
        animator.Play(SHOOT_ANIMATION, 0, 0f);

        starterAssetsInputs.ShootInput(false);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVfxPrefab, hit.point, quaternion.identity);

            Health enemyHealth = hit.collider.GetComponent<Health>();
            enemyHealth?.takeDamage(WeaponSo.Damage); // Changes damage according to the scriptable attached

            // starterAssetsInputs.ShootInput(false);
            //if (enemyHealth != null) 
            //{ 
            //    enemyHealth.takeDamage(gunDamage);
            //    starterAssetsInputs.ShootInput(false);
            //}
        }
    }
}
