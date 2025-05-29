using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        var fireHealth = other.GetComponentInChildren<FireHealth>();
        if (fireHealth)
        {
            fireHealth.DecraseHealth();
        }
    }
}
