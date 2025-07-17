using Unity.Cinemachine;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject prefabs;
    public GameObject HitVfxPrefab;
    public int Damage = 30;
    public float FireRate;
    public bool isAutomatic = false;
    public bool canZoom = false;
    public float ZoomAmount = 10f;
    public float RotationSpeed = 0.4f;
    public int MagzineSize = 0;
}
