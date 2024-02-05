using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SunManager : MonoBehaviour
{
    [SerializeField]
    int currentStage;
    public List<GameObject> Suns;
    GameManager manager;
    public int needSweat;

    void Start()
    {
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
        int sweat = manager.sweat;
        if (sweat >= needSweat)
        {
            sweat = sweat - needSweat;
            currentStage = currentStage + 1;
        }
    }


}
