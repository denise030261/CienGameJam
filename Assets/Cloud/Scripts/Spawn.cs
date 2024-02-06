using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private bool isFog=false;
    private bool isDown = false;
    private bool isChange = false;

    [SerializeField]
    private bool isRow = false;

    [SerializeField]
    private GameObject[] projectiles; // �߻�ü

    [SerializeField]
    private float spawnSpeed=1f; // ���� �ݺ� �ӵ�

    [SerializeField]
    private float spawnMinSpeed = 1f; // ���� �ݺ� �ӵ�

    [SerializeField]
    private float spawnMaxSpeed = 1f; // ���� �ݺ� �ӵ�

    [SerializeField]
    private float spawnSpeedDown = 1f; // �󸶳� �ӵ��� ������

    [SerializeField]
    private float spawnXMax; // ���� X �ִ� �ݰ�

    [SerializeField]
    private float spawnXMin; // ���� X �ּ� �ݰ�

    void Start()
    {
        randomSpeed();
    }

    private void Update()
    {
        if(GameManager.Instance.stage==4 && !isDown)
        {
            isDown = true;
        }

        if(isDown && !isChange)
        {
            isChange = true;
            spawnMaxSpeed -= spawnSpeedDown;
        }
    }
    void SpawnObject()
    {
        float spawnX = Random.Range(spawnXMin, spawnXMax);

        Vector2 spawnTransform = new Vector2(this.transform.position.x + spawnX,
            this.transform.position.y);

       if (GameManager.Instance.stage >= 4 && !isRow)
        {
            Debug.Log("4���� ����");
            int num = Random.Range(0, 2);
            Instantiate(projectiles[num], spawnTransform, Quaternion.identity);
        }
        else if (GameManager.Instance.stage >= 1 && !isRow)
        {
            Debug.Log("1���� ����");
            Instantiate(projectiles[0], spawnTransform, Quaternion.identity);
        }

        if (GameManager.Instance.stage>=2 && isRow)
        {
            Debug.Log("2���� ����");
            Instantiate(projectiles[0], spawnTransform, Quaternion.identity);
        }
        
        if (GameManager.Instance.stage == 3 && !isFog && !isRow)
        {
            Debug.Log("3���� ����");
            spawnTransform = new Vector2(0, 0);
            Instantiate(projectiles[2], spawnTransform, Quaternion.identity);
            isFog = true;
        }
        

        randomSpeed();
    }

    void randomSpeed()
    {
        spawnSpeed = Random.Range(spawnMinSpeed, spawnMaxSpeed);
        Invoke("SpawnObject", spawnSpeed);
    }
}
