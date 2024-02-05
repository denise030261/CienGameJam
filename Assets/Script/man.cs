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
        if (Hp > 90)
        {
            
        }
        else if (Hp > 75)
        {
            ManSprites[0].SetActive(false);

        }else if (Hp > 50)
        {
            ManSprites[1].SetActive(false);
        }else if (Hp > 25)
        {
            ManSprites[2].SetActive(false);
        }else if (Hp > 0)
        {
            ManSprites[3].SetActive(false);
        }
        else
        {
            ManSprites[4].SetActive(false);
        }
        
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
