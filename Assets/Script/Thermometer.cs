using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour
{

    public Slider slider;
    public man man;
    public void Start()
    {
       
    }
    public void Update()
    {
        slider.value = man.Hp;
    }

    
}
