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
    int BeamLevel;
    public List<GameObject> Suns;
    public List<Button> buttons;
    public Button powerButton;
    public Button dropButton;
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
        switch (BeamLevel)
        {
            case 0:
                ChangeBeam(BeamLevel);
                break;
            case 1:
                Suns[BeamLevel - 1].SetActive(false);
                ChangeBeam(BeamLevel);
                break;
            case 2:
                Suns[BeamLevel - 1].SetActive(false);
                ChangeBeam(BeamLevel);
                break;
            case 3:
                Suns[BeamLevel - 1].SetActive(false);
                ChangeBeam(BeamLevel);
                break;
            default: 
                break;
        }
    }

    void ChangeBeam(int BeamLevel)
    {
        Suns[BeamLevel].SetActive(true);
    }

    public void BeamUpgrade()
    {
        int sweat = GameManager.Instance.sweat;
        if (sweat >= needSweat)
        {
            buttons[BeamLevel].interactable = false;
            GameManager.Instance.sweat = sweat - needSweat;
            BeamLevel = BeamLevel + 1;
            
            if (BeamLevel < 3)
            {
                buttons[BeamLevel].interactable = true;
            }
        }
    }
    public void dropUp()
    {
        int sweat = GameManager.Instance.sweat;
        if (sweat >= 100)
        {
            dropButton.interactable = false;
            GameManager.Instance.sweat = sweat - 100;
            GameManager.Instance.EmissionRate = newRateOverTime;

            // ��ƼŬ �ý����� Emission ��⿡ ����
            //var emissionModule = myParticleSystem.emission;

            // rate over time ���� ����
            //emissionModule.rateOverTime = newRateOverTime;
            Debug.Log("�� ���� �Ƴ�?");
        }
    }

    public void beamPowerUp()
    {
        int sweat = GameManager.Instance.sweat;
        if (sweat >= 100)
        {
            powerButton.interactable = false;
            GameManager.Instance.sweat = sweat - 100;

            powerUp = true;
            Debug.Log("�� ���� �Ƴ�?");
        }
    }
}
