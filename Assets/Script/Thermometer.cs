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
        slider.maxValue = man.MaxHp;
        slider.value = man.MaxHp-man.Hp;
    }

    
}
