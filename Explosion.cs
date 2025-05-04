using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 3;
    [SerializeField] AudioSource explosionAudioSource;

    void Start()
    {
        Explode();
        PlayExplosionSound();
        if (explosionAudioSource != null && explosionAudioSource.clip != null)
        {
            Destroy(gameObject, explosionAudioSource.clip.length);
        }
        else
        {
            Destroy(gameObject, 2f); 
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            PlayerHealth playerhealth = hitCollider.GetComponent<PlayerHealth>();
            if (!playerhealth) continue;
            playerhealth.TakeDamage(damage);
            break;
        }
    }

    void PlayExplosionSound()
    {
        if (explosionAudioSource != null && explosionAudioSource.clip != null)
        {
            explosionAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Explosion AudioSource is not assigned or has no clip!");
        }
    }
}
