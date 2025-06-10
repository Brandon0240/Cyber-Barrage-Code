using UnityEngine;

public class GunController : MonoBehaviour
{
    public AudioSource gunAudioSource;

    void Start()
    {
      
        if (gunAudioSource == null)
        {
            gunAudioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireGun();
        }
    }

    void FireGun()
    {
        gunAudioSource.Play();
    }
}
