using UnityEngine;

public class FireHealth : MonoBehaviour
{
    public ParticleSystem fireParticles;
    public float health = 100f;
    public float damagePerFoamParticle = 5f; // Урон от одной частицы пены

    void Start()
    {
        if (fireParticles == null)
            fireParticles = GetComponent<ParticleSystem>();
    }

    public void DecraseHealth()
    {
        health -= 10;
        if (health < 0)
        {
            fireParticles.gameObject.SetActive(false);
        }
    }


    void ExtinguishFire()
    {
        fireParticles.Stop(); // Останавливаем огонь
        Destroy(gameObject, 1f); // Удаляем через 1 секунду
    }
}