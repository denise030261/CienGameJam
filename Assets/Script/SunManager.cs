using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SunManager : MonoBehaviour
{
    [SerializeField]
    int currentStage;
    public List<GameObject> Suns;
    public List<Button> buttons;
    GameManager manager;
    public int needSweat;
    public bool powerUp;

    public ParticleSystem myParticleSystem;
    public float newRateOverTime = 20f;

    void Start()
    {
        powerUp = false;
        // ���� ���� ��
        ChangeBeamOnStage();
    }

    private void Update()
    {
        ChangeBeamOnStage();
    }

    void ChangeBeamOnStage()
    {
        // �� ���������� ���� �� ����
        switch (currentStage)
        {
            case 0:
                ChangeBeam(currentStage);
                break;
            case 1:
                Suns[currentStage-1].SetActive(false);
                ChangeBeam(currentStage);
                break;
            case 2:
                Suns[currentStage - 1].SetActive(false);
                ChangeBeam(currentStage);
                break;
            case 3:
                Suns[currentStage - 1].SetActive(false);
                ChangeBeam(currentStage);
                break;
            default: 
                break;
        }
    }

    void ChangeBeam(int stageLevel)
    {
        Suns[stageLevel].SetActive(true);
    }

    public void BeamUpgrade()
    {
        int sweat = GameManager.Instance.sweat;
        if (sweat >= needSweat)
        {
            buttons[currentStage].interactable = false;
            GameManager.Instance.sweat = sweat - needSweat;
            currentStage = currentStage + 1;
            
            if (currentStage < 5)
            {
                buttons[currentStage].interactable = true;
            }
            if(currentStage>=4)
            {
                powerUp = true;
            }
            if(currentStage >= 5)
            {
                // ��ƼŬ �ý����� Emission ��⿡ ����
                var emissionModule = myParticleSystem.emission;

                // rate over time ���� ����
                emissionModule.rateOverTime = newRateOverTime;
            }
        }

    }

}
