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
        // 게임 시작 빔
        ChangeBeamOnStage();
    }

    private void Update()
    {
        ChangeBeamOnStage();
    }

    void ChangeBeamOnStage()
    {
        // 각 스테이지에 따라 빔 변경
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
        if (sweat >= needSweat)
        {
            dropButton.interactable = false;
            GameManager.Instance.sweat = sweat - needSweat;

            // 파티클 시스템의 Emission 모듈에 접근
            var emissionModule = myParticleSystem.emission;

            // rate over time 값을 변경
            emissionModule.rateOverTime = newRateOverTime;
            Debug.Log("값 변경 됐나?");
        }
    }

    public void beamPowerUp()
    {
        int sweat = GameManager.Instance.sweat;
        if (sweat >= needSweat)
        {
            powerButton.interactable = false;
            GameManager.Instance.sweat = sweat - needSweat;

            powerUp = true;
            Debug.Log("값 변경 됐나?");
        }
    }
}
