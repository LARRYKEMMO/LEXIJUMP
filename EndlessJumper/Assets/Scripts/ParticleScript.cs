using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public GameObject ParticleSystem;
    private GameObject Particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayParticle(Vector3 Position)
    {
        Particle = Instantiate(ParticleSystem, Position, Quaternion.identity);

    }
}
