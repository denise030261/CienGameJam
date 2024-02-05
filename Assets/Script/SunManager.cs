using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    private man Man;

    private void Start()
    {
        Man = GameObject.Find("Man").GetComponent<man>();

    }

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Man.Hp-=5;
        }

    }
}
