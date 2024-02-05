using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    private SpriteRenderer fogImage;
    private float delayTime;
    private bool isFadein;
    private bool isFadeout;
    private bool isStart; // �Ȱ� �ߵ� ����

    [SerializeField]
    private float delayMinTime; // �����ּҽð�

    [SerializeField]
    private float delayMaxTime; // �����ִ�ð�

    [SerializeField]
    private float ExistTime; // �Ȱ��� �����ϴ� �ð�

    [SerializeField]
    private float fadeSpeed; // Fade �ð�

    // Start is called before the first frame update
    void Start()
    {
        fogImage = GetComponent<SpriteRenderer>();
        delayTime = Random.Range(delayMinTime, delayMaxTime);
        Init();
        StartCoroutine(CloseFog());
    }

    private void Update()
    {
        if(isFadein)
        {
            fogImage.color = new Color(fogImage.color.r, fogImage.color.g, fogImage.color.b,
                fogImage.color.a+Time.deltaTime* fadeSpeed);

            if(fogImage.color.a>=1f)
            {
                isFadein = false;
                StartCoroutine(OpenFog());
            }
        }
        else if(isFadeout)
        {
            fogImage.color = new Color(fogImage.color.r, fogImage.color.g, fogImage.color.b,
                fogImage.color.a - Time.deltaTime * fadeSpeed);

            if (fogImage.color.a <= 0f)
            {
                isFadeout = false;
                StartCoroutine(CloseFog());
            }
        }
    }

    void Init()
    {
        isFadein = false;
        isFadeout = false;
        fogImage.color = new Color(fogImage.color.r, fogImage.color.g, fogImage.color.b, 0f);
        isStart = false;
    }

    IEnumerator OpenFog()
    {
        yield return new WaitForSeconds(ExistTime);
        isFadeout = true;
    } // �Ȱ� ���� �ð�

    IEnumerator CloseFog()
    {
        yield return new WaitForSeconds(delayTime);
        isFadein = true;
    } // �Ȱ� �� �������� �ð�
}
