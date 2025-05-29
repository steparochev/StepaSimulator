using UnityEngine;

public class FireExtinguisherController : MonoBehaviour
{
    public ParticleSystem foamParticles;
    public AudioSource spraySound;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!foamParticles.isPlaying)
                foamParticles.Play();
        }
        else
        {
            if (foamParticles.isPlaying)
                foamParticles.Stop();
        }
    }
}