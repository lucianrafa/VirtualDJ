using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField]private ParticleSystem[] systems;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (transform.rotation.normalized.z > 0.40f)
        {
            foreach (var system in systems)
            {
                system.Play();
            }
            
        }else if (transform.rotation.normalized.z < -0.30f)
        {
            foreach (var system in systems)
            {
                system.Stop();
            }
        }
    }
}
