using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    public Slider slider;


    public float Time;
    public float MaxTime = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.Instance.Time;
    }
}