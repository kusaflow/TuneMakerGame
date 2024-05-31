using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleOnCollition : MonoBehaviour
{
    public GameObject particleGameObject;
    public float scale_of_particle = .4f;
    //2d collition
    public  void PlayParticleEffect(Collision2D collision)
    {
         
        //intantiate gameobject of this particle system that destroy itself after the particle system is done
        GameObject particleGO = Instantiate(particleGameObject, collision.GetContact(0).point, Quaternion.identity);
        //scale the particle
        particleGO.transform.localScale = new Vector3(scale_of_particle, scale_of_particle, scale_of_particle);
        //get the particle system component and play it
        ParticleSystem particleSystem = particleGO.GetComponent<ParticleSystem>();
        
        ParticleSystem.MainModule main = particleSystem.main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        particleGO.transform.position = collision.GetContact(0).point;
        particleSystem.Play();

        Destroy(particleGO, particleSystem.GetComponent<ParticleSystem>().main.duration);

    }
}
