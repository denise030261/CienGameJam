using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SweatIndicate : MonoBehaviour
{
    public TMP_Text Sweatindicator;
    private int SweatAmount;
    // Start is called before the first frame update
    void Start()
    {
        SweatAmount = 0;
    }


    // Update is called once per frame
    void Update()
    {
        SweatAmount = GameManager.Instance.sweat;
        Sweatindicator.text = "Score : " + SweatAmount;
        
    }
    }

