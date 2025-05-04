using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] protected AudioSource pickupAudioSource;
    const string PLAYER_STRING = "Player";
    bool hasBeenPickedUp = false;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasBeenPickedUp) return;

        ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
        if (other.CompareTag(PLAYER_STRING) && activeWeapon != null)
        {
            hasBeenPickedUp = true;
            OnPickup(activeWeapon);
            PlayPickupSound();
            DisableAndDestroy();
        }
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);

    protected void PlayPickupSound()
    {
        if (pickupAudioSource != null && pickupAudioSource.clip != null)
        {
            pickupAudioSource.Play();
        }
        else
        {
            Debug.LogWarning(gameObject.name + " Pickup Audio Source is not assigned or has no clip!");
        }
    }

    protected void DisableAndDestroy()
    {
        GetComponent<Collider>().enabled = false;
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

        if (pickupAudioSource != null && pickupAudioSource.clip != null)
        {
            Destroy(gameObject, pickupAudioSource.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}