using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO" , menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public bool isAutomatic= false;
    public GameObject HitVFXPrefab;
    public bool CanZoom = false;
    public float ZoomAmount = 10f;
    public float ZoomRotationSpeed = 0.3f;
    public int MagazineSize = 12;
    public AudioClip shootSound;
}
