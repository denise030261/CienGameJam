using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man : MonoBehaviour
{
    public int Hp;
    public ParticleSystem Sweat;
    private bool _wait = false;

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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.name == "SunBeam")
            StartCoroutine(Damage());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.name=="SunBeam")
            Sweat.Stop();
    }

    private IEnumerator Damage()
    {
        if (_wait) yield break;
        _wait = true;
        Hp -= 10;
        yield return new WaitForSeconds(0.5f);
        
        _wait = false;
    }
}
