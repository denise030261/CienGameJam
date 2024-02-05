using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man : MonoBehaviour
{
    public int Hp;

    public List<GameObject> ManSprites;
    // Start is called before the first frame update

    private void Update()
    {
        if (Hp<90&&Hp > 75)
        {
            //ManSprites[].SetActive(false);

        }else if (Hp > 50)
        {
            ManSprites[0].SetActive(false);
        }else if (Hp > 25)
        {
            ManSprites[1].SetActive(false);
        }else if (Hp > 0)
        {
            ManSprites[2].SetActive(false);
        }
        else
        {
            ManSprites[3].SetActive(false);
        }
        
    }
}
