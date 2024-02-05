using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man : MonoBehaviour
{
    public int Hp;

    public List<Sprite> ManSprites;
    // Start is called before the first frame update

    private void Update()
    {
        if (Hp > 75)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ManSprites[0];

        }else if (Hp > 50)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ManSprites[1];
        }else if (Hp > 25)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ManSprites[2];
        }else if (Hp > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ManSprites[3];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ManSprites[4];
        }
        
    }
}
