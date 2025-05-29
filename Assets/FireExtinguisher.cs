using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    public ParticleSystem foamParticles;
    public AudioSource spraySound;
    public KeyCode sprayKey = KeyCode.Mouse0; // Или другая клавиша

    void Awake()
    {
        if (spraySound == null)
        {
            spraySound = gameObject.AddComponent<AudioSource>();
            Debug.Log("Created new AudioSource");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(sprayKey))
        {
            StartSpray();
        }
        else if (Input.GetKeyUp(sprayKey))
        {
            StopSpray();
        }
    }

    public void StartSpray()
    {
        foamParticles.Play();
        spraySound.Play();
    }

    void StopSpray()
    {
        if (foamParticles != null) foamParticles.Stop();
        if (spraySound != null) spraySound.Stop();
    }
}