using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public int temperature;
    public int maxTemp;

    private void Awake()
    {
        temperature = 0;
        maxTemp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            temperature++;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            
        }
    }
}
