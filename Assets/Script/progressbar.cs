using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Slider>().maxValue=GameManager.Instance.MaxTime;
        gameObject.GetComponent<Slider>().minValue = 0;
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.Instance.Time;
    }
}