using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    [SerializeField]
    int currentStage;
    public List<GameObject> Suns;

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
}
