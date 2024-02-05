using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    private SpriteRenderer fogImage;
    private float delayTime;
    private bool isFadein;
    private bool isFadeout;
    private bool isStart; // 안개 발동 여부

    [SerializeField]
    private float delayMinTime; // 간격최소시간

    [SerializeField]
    private float delayMaxTime; // 간격최대시간

    [SerializeField]
    private float ExistTime; // 안개가 존재하는 시간

    [SerializeField]
    private float fadeSpeed; // Fade 시간

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
    } // 안개 유지 시간

    IEnumerator CloseFog()
    {
        yield return new WaitForSeconds(delayTime);
        isFadein = true;
    } // 안개 뜰 때까지의 시간
}
