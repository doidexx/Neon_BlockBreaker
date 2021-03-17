using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<ParticleSystem>().IsAlive()) return;
        Destroy(gameObject);
    }
}
