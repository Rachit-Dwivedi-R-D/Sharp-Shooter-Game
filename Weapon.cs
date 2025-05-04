using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactionLayers;
    CinemachineImpulseSource impulsseSource;

    void Awake()
    {
        impulsseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        impulsseSource.GenerateImpulse();

        
        if (weaponSO != null && weaponSO.shootSound != null)
        {
            
            ActiveWeapon activeWeapon = GetComponentInParent<ActiveWeapon>();
            if (activeWeapon != null && activeWeapon.weaponAudioSource != null)
            {
                activeWeapon.weaponAudioSource.PlayOneShot(weaponSO.shootSound);
            }
            else
            {
                Debug.LogWarning("ActiveWeapon script or AudioSource not found in parent for sound playback.");
            }
        }
        else if (weaponSO == null)
        {
            Debug.LogWarning("WeaponSO is null in the Shoot function.");
        }
        else
        {
            Debug.Log("No shoot sound assigned to this weapon in the WeaponSO.");
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactionLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
            // if (enemyHealth != null)
    // {
    //     enemyHealth.TakeDamage(weaponSO.Damage);
    //     Debug.Log("Applied " + weaponSO.Damage + " damage to " + hit.collider.gameObject.name);
    // }
    // else
    // {
    //     Debug.LogWarning("EnemyHealth component not found on " + hit.collider.gameObject.name + " or its parents.");
    // }
        }
    }
}
