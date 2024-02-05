using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man : MonoBehaviour
{
    public int Hp;
    public ParticleSystem Sweat;

    public List<GameObject> ManSprites;
    // Start is called before the first frame update

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name=="SunBeam")
            Sweat.Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.name=="SunBeam")
            Sweat.Stop();
    }
}
